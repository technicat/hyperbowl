// Copyright Technicat LLC
//  FSM for HyperBowl lane

using UnityEngine;
using System.Collections;

using TMPro;

namespace Hyper {

	public enum Difficulty {
		Novice = 0,
		Intermediate = 1,
		Expert = 2
	};


	class HyperPlayer {
		public string name;
		public Texture2D photo;
		public FrameScore[] scores;
	}

	public class FrameScore {
		public int ball1;
		public int ball2;
		public int ball3;
		public int total;
	}

public class Bowl : Lane {

	
	public Difficulty difficulty = Difficulty.Novice;
	// camera flythru duration - varies per scene
	public float flycamtime = 1f;

	// gutterball boundaries
	public float guttery = 0f;
	public float gutterleft = 1000f;
	public float gutterright = -1000f;
	public float gutterfar = -1000f;

	// position of the pin rack (frontmost pin)
	private Vector3 pincenter;

	// objects that need to be reset after each roll
		public  GameObject[] resetobjects;

	// lane number, 1-6 for the originals
	public int level;

	private float pindistance = 3.5f;

	private GameObject[] pins;
	private bool[] pinsdown;

	private GameObject namewing;
	private GameObject nametext;
	private GameObject namepic;

	private GameObject bowltext;
	private float bowltexttime = 4f;

	private float bowl1time = 0.1f;

	private GameObject bowl2text;
	private float bowl2time = 2.0f;

	private GameObject bonusballtext;
	private float bonusballtime = 2.0f;

	private GameObject gameovertext;
	private float gameovertime = 5.0f;


	// hyperbowl logo above scoreboard
	private GameObject scorelogo;

		private GameObject[] scoreboards;
	private float scoretime = 5f;

	private GameObject gutter;
	private float guttertime = 6f;

	private GameObject spare;
	private float sparetime = 4;

	private GameObject strike;
	private float striketime = 4;

	private GameObject timeout;
	private float timeouttime = 4;

	private GameObject pinstatus;
	private float pinsettletime =5;

	private int numstrikes = 0; // consecutive strikes
	private int maxstrikes = 0; // maximum consecutive strikes

	

	// cached components
	private Transform balltrans; // ball transform

	static public bool gutterTriggered = false;

	static public  int currentplayer;
	// current player 0-3

	// frame 0-9, corresponds to 1-10
	static public int frame;

	// ball 0-2, corresponding to ball1, ball2 and bonus ball
	static public int roll;

	static HyperPlayer[] hyperplayers;

	void HyperScoreClear(int p) {
		for (int i=0; i<hyperplayers[p].scores.Length; ++i) {
			FrameScore score = hyperplayers[p].scores[i];
			score.ball1=-1;
			score.ball2=-1;
			score.ball3=-1;
			score.total=-1;
		}
	}

	static HyperPlayer GetCurrentPlayer() {
		return hyperplayers[currentplayer];
	}

	static public string GetPlayerName(int p) {
		return hyperplayers[p].name;
	}

	static public string GetSinglePlayerName() {
		return hyperplayers[0].name;
	}

	static public FrameScore[] GetCurrentScores() {
		return GetCurrentScores(currentplayer);
	}

		static public FrameScore[] GetCurrentScores(int p)  {
		return hyperplayers[p].scores;
	}

	static int GetSinglePlayerScore() {
		return GetScore(9,0);
	}

	static public int GetScore(int f) {
		return GetScore(f,currentplayer);
	}

	// return score for given player and frame, -1 if score has not finalized
	static public int GetScore(int f, int playerindex) {
			FrameScore[] scores = GetCurrentScores(playerindex);
		if (f==0 || scores[f].total==-1) {
			return scores[f].total;
		} else {
			int prev = GetScore(f-1,playerindex);
			if (prev==-1) {
				return -1;
			} else {
				return scores[f].total+prev;
			}
		}
	}

	static bool IsStrike(int f) {
		return IsStrike(f,currentplayer);
	}

	static  bool IsStrike(int f, int playerindex) {
			FrameScore[] scores = GetCurrentScores(playerindex);
			FrameScore framescore = scores[f];
		return framescore.ball1 == 10;
	}

	// only for tenth frame

	static bool IsSecondStrike(int playerindex) {
			FrameScore[] scores = GetCurrentScores(playerindex);
			FrameScore framescore = scores[9];
		return framescore.ball2 == 10;
	}

	static bool IsThirdStrike(int playerindex) {
			FrameScore[] scores = GetCurrentScores(playerindex);
			FrameScore framescore = scores[9];
		return framescore.ball3 == 10;
	}

	static public bool IsSpare(int f) {
		return IsSpare(f,currentplayer);
	}

	static public bool IsSpare(int f, int playerindex) {
			FrameScore[] scores = GetCurrentScores(playerindex);
			FrameScore framescore = scores[f];
		// doesn't handle spare on ball3
		return !IsStrike(f,playerindex) &&
			(framescore.ball1 + framescore.ball2 == 10);
	}

	static void Play(GameObject obj) {
		if (obj != null) {
			Fugu.ObjectUtils.ActivateChildren(obj);
			obj.BroadcastMessage("Play");
		}
	}

	void InitPlayers() {
		hyperplayers = new HyperPlayer[Game.numplayers];
		for (int p = 0; p<Game.numplayers; ++p) {
			HyperPlayer player = new HyperPlayer();
			player.scores = new FrameScore[10];
			for (int i=0; i<player.scores.Length; ++i) {
				player.scores[i] = new FrameScore();
			}
			string playerkey = "Player"+(p+1)+"Name";
			player.name = PlayerPrefs.GetString(playerkey,"PLAYER");
			player.photo = null;
			hyperplayers[p] = player;
		}
		SetSinglePlayerName();
	}

	// init variables

	void InitScoreboards() {
		scorelogo = GameObject.FindWithTag("Scorelogo");
		scoreboards=new GameObject[4];
		scoreboards[0]=GameObject.FindWithTag("Scoreboard1");
		scoreboards[1]=GameObject.FindWithTag("Scoreboard2");
		scoreboards[2]=GameObject.FindWithTag("Scoreboard3");
		scoreboards[3]=GameObject.FindWithTag("Scoreboard4");
	}

	void InitHUDText() {
		bowl2text = GameObject.FindWithTag("Ball2");
		bonusballtext = GameObject.FindWithTag("BonusBall");
		gameovertext = GameObject.FindWithTag("GameOver");
	}

	void InitNameWing() {
		namewing = GameObject.FindWithTag("Namewing");
		Fugu.ObjectUtils.ActivateChildren(namewing);
		nametext = GameObject.FindWithTag("Nametext");
		namepic = GameObject.FindWithTag("ProfilePic");
		Fugu.ObjectUtils.DeactivateChildren(namewing);
	}

	void Init3DText() {
		gutter = GameObject.FindWithTag("Gutter");
		timeout = GameObject.FindWithTag("Timeout");
		strike = GameObject.FindWithTag("Strike");
		spare = GameObject.FindWithTag("Spare");
		bowltext = GameObject.FindWithTag("Bowl");
	}

	void InitPins() {
		pins = new GameObject[10];
		pinsdown = new bool[10];
		for (int i=0; i<10; ++i) {
			pins[i]=GameObject.FindWithTag("Pin"+(i+1));
			pinsdown[i]=false;
		}
		pincenter = GameObject.FindWithTag("Pin10").transform.position;
	}

	// finished rolling
	override protected void StopRolling() {
		base.StopRolling();
		Fugu.ObjectUtils.DeactivateChildren(namewing);
	}

	override protected void StartRolling() {
		base.StartRolling();
		Fugu.ObjectUtils.ActivateChildren(namewing);
	}

	void ResetCamera() {
		Camera.main.SendMessage("ResetPosition");
		FollowEnable(true);
	}

	// move ball back to start position
	void ResetBall() {
		gutterTriggered = false;
		HideScoreBoard();
		ball.SendMessage("ResetPosition");
		ResetCamera();
	}

	void RemoveDownedPins() {
		for (int i=0; i<pins.Length; ++i) {
			if (pinsdown[i]) {
				pins[i].SetActive(false);
			} else {
				ResetPin(i);
			}
		}
	}

	void ResetPins() {
		for (int i=0; i<pins.Length; ++i) {
			pins[i].SetActive(true);
			ResetPin(i);
		}
	}

	void ResetPin(int i) {
		pins[i].SendMessage("ResetPosition");
		pinsdown[i]=false;
	}

	void ResetAll() {
		for (int i=0; i<resetobjects.Length; ++i) {
			resetobjects[i].BroadcastMessage("ResetPosition",null,SendMessageOptions.DontRequireReceiver);
		}
	}

	bool GutterBall() {
		return (gutterTriggered || (balltrans.position.y<guttery) ||( balltrans.position.x>gutterleft) || (balltrans.position.x<gutterright) || (balltrans.position.z<gutterfar)); 
	}

	// count pins knocked over
	int GetPinsDown() {
		int total = 0;
		for (int i=0; i<pinsdown.Length; ++i) {
			if (pinsdown[i]) {
				total +=1;
			}
		}
		return total;
	}


	// count pins knocked over
	void UpdatePinsDown() {
		for (int i=0; i<pins.Length; ++i) {
				PinStatus status = pins[i].GetComponent<PinStatus>();
			pinsdown[i]=status.KnockedOver();
		}
	}

	// update current frame score with current pin state
	void UpdateScore() {
		UpdatePinsDown();
		switch (roll) {
		case 0:	SetBall1Score(); break;
		case 1: SetBall2Score(); break;
		case 2: SetBall3Score(); break;
		}
	}

	// set the ball 1 score of the current frame
	void SetBall1Score() {
			FrameScore[] scores = GetCurrentPlayer().scores;
		int score = GetPinsDown();
			FrameScore framescore = scores[frame];
		framescore.ball1=score;
		// if previous frame was a spare, set its score
		if (frame>0 && IsSpare(frame-1)) {
			SetSpareScore(frame-1);
		}
		// if the previous two frames were strikes, then set the score of the first frame
		if (frame>1 && IsStrike(frame-1) && IsStrike(frame-2)) {
			SetStrikeScore(frame-2);
		}
	}

	// set the ball 2 score of the current frame
	void SetBall2Score() {
			FrameScore[] scores = GetCurrentPlayer().scores;
		int score = GetPinsDown();
		FrameScore framescore = scores[frame];
		if (IsStrike(frame)) {
			framescore.ball2=score; // final frame
		} else {
			framescore.ball2=score-framescore.ball1;
		}
		// calculate this frame's score if it isn't a spare or strike
		if (!IsSpare(frame) && !IsStrike(frame)) {
			framescore.total= score;
		}
		// if previous frame was a strike then set its score
		if (frame>0 && IsStrike(frame-1)) {
			SetStrikeScore(frame-1);
		}
	}

	// set the ball 3 score of the current frame (final frame)
	void SetBall3Score() {
			FrameScore[] scores = GetCurrentPlayer().scores;
		int score = GetPinsDown();
			FrameScore framescore = scores[frame];
		if (IsStrike(frame) && framescore.ball2 <10) {
			framescore.ball3 = score - framescore.ball2;
		} else {
			framescore.ball3 = score; // spare or two strikes
		}
		framescore.total = framescore.ball1+framescore.ball2+framescore.ball3;
	}

	// calculate and set the strike score for the given frame
	// not called for the final frame
	void SetStrikeScore(int f) {
			FrameScore[] scores = GetCurrentPlayer().scores;
			FrameScore framescore = scores[f];
		framescore.total = framescore.ball1;
		// always add the score from first roll of the next frame
		framescore.total+=scores[f+1].ball1;
		// if not the ninth or tenth frame, and the next frame is a strike, then add the the ball1 score from the frame after that
		if (f < 8 && IsStrike(f+1)) {
			framescore.total+=scores[f+2].ball1;
		} else {
			// for the ninth frame (frame 8) add the second ball from the next (final) frame (there always is one)
			framescore.total+=scores[f+1].ball2;
		}
	}

	// calculate and set the spare score for the given frame
	void SetSpareScore(int f) {
			FrameScore[] scores = GetCurrentPlayer().scores;
			FrameScore framescore = scores[f];
		// the score is the score of both rolls in this frame and teh first roll of the next
		framescore.total = framescore.ball1+framescore.ball2+scores[f+1].ball1;
	}

	void ShowScoreBoard() {
		Play(scorelogo);
		Play(scoreboards[currentplayer]);
	}

	void HideScoreBoard() {
		Fugu.ObjectUtils.DeactivateChildren(scorelogo);
		for (int i=0; i<Game.numplayers; ++i) {
			Fugu.ObjectUtils.DeactivateChildren(scoreboards[i]);
		}
	}

	// update the name wing - move this to the object?
	void UpdateName() {
		if (nametext != null) {
				TMP_Text text3d = nametext.GetComponent<TMP_Text>(); // should only do this when player changes
				text3d.text = GetCurrentPlayer().name;
		}
		if (namepic != null) {
				Texture2D photo = GetCurrentPlayer().photo;
			if (photo != null) {
				namepic.GetComponent<Renderer>().material.mainTexture = photo;
				namepic.GetComponent<Renderer>().enabled = true;
			} else {
				namepic.GetComponent<Renderer>().enabled = false;
			}
		} else {
			//		namepic.GetComponent.<Renderer>().enabled = false;
		}
	}

	void PostScore() {
		int score = GetSinglePlayerScore();
		int complete = 100;
		// for incomplete game (quit from lane)
		if (score == -1) { 
			score = 0; // score is zero (looks better than -1)
			complete = frame*10; // completion is 0-90
		}
		//var maxstrikes:int=GetConsecutiveStrikes();
		switch (Game.mode) {
		case Game.Mode.ARCADE:
			break;
		case Game.Mode.GAMECENTER:
			// note we used "HyperBowl" for scores and "hyperbowl" for achievements. Oops.
			GameCenter.Score(level,score);// "grp.com.technicat.HyperBowl.lane"+level+".free",score);
			// level completion achievement
			GameCenter.AchievementLane(level, complete); // (GameCenter.achievementLane(level), complete); // "grp.com.technicat.hyperbowl.complete"+level, complete);
			// difficulty achievements
			GameCenter.AchievementDifficulty((int)difficulty, complete); // (GameCenter.achievementDifficulty((int)difficulty), complete);
			#if UNITY_IOS || UNITY_TVOS
			// scoring achievements
			Fugu.GameCenter.Achievement("grp.com.technicat.hyperbowl.perfect", (100*score)/300);
			#endif
			// consecutive strike
			/*		if (maxstrikes>0 && maxstrikes<HyperGameCenter.strikeAchievements.length+1) {
			Fugu.GameCenter.Achievement(HyperGameCenter.strikeAchievements[maxstrikes-1],100);
		} */
			break;
			
		}
		
		Fugu.Stats.Score(laneName,GetSinglePlayerName(),complete,score);
	}

	void SetSinglePlayerName(string name) {
		if (name != null && name != "") {
			hyperplayers[0].name=name; // overwrite playerperfs default
		}
	}

		void SetSinglePlayerPhoto(Texture2D photo) {
		if (photo != null) {
			hyperplayers[0].photo=photo; // overwrite playerperfs default
		}
	}

	// get player names from game network
	void SetSinglePlayerName() {
		switch (Game.mode) {
		case Game.Mode.GAMECENTER:
			SetSinglePlayerName(Fugu.GameCenter.playerName);
			SetSinglePlayerPhoto(Fugu.GameCenter.photo);
			break;
		default:
			break;
		}
	}

	// state machine

	// init callbacks

	override public void Awake() {
		base.Awake();
		InitPins();
		InitScoreboards();
		InitHUDText();
		InitNameWing();
		Init3DText();
		pinstatus = GameObject.FindWithTag("Pinstatus");
		balltrans = ball.transform;
		InitPlayers();
	}


	// each of these functions are coroutines/states

	override public void Start() {
		// clear scores
		for (int p=0; p<Game.numplayers; ++p) {
			HyperScoreClear(p);
		}
		frame=0;
		roll=0;
		currentplayer=0;
		numstrikes=0;
		maxstrikes=0;
		UpdateName();
		Camera.main.SendMessage("StartPosition"); // in front of pins
		base.Start();
	}

	override public IEnumerator WipeOpen() {
		yield return base.WipeOpen();
		state = "StateFlyCam";
	}

	// state for camera flythrough
	IEnumerator StateFlyCam() {
		UAP_AccessibilityManager.Say("Fly through");
		Camera.main.SendMessage("PlayAnimation");
		float flycamtime = Camera.main.GetComponent<FlyThruAnim>().animTime;
		yield return WaitOrQuit(flycamtime); // new WaitForSeconds(flycamtime);
		if (checkQuit())  {
			yield break;
		}
		// for single-lane apps, always start with pause menu
		#if !HYPERALL
		Fugu.PauseMenu.PauseGame();
		#endif
		state = "StateBowlText";
	}

	// state to display initial BOWL text
	IEnumerator StateBowlText() {
		UAP_AccessibilityManager.Say("Bowl!");
		Play(bowltext);
		yield return WaitOrQuit(bowltexttime);
		Fugu.ObjectUtils.DeactivateChildren(bowltext);
		if (checkQuit())  {
			yield break;
		}
		state = "StateBowlFrame";
	}

	// state to begin frame
	IEnumerator StateBowlFrame() {
		state = "StateBall1";
		yield return null;
	}

	// state to begin first ball
	IEnumerator StateBall1() {
		UAP_AccessibilityManager.Say("Ball one");
		ResetBall();
		ResetPins();
		ResetAll();
		roll = 0;
		yield return WaitOrQuit(bowl1time);
		if (checkQuit()) {
			yield break; 
		}
		state = "StateRoll";
	}

	// state to begin second ball
	IEnumerator StateBall2() {
		UAP_AccessibilityManager.Say("Ball two");
		RemoveDownedPins();
		ResetBall();
		// tenth frame
		if (GetPinsDown()==10) {
			ResetPins();
		}
		roll = 1;
		Play(bowl2text);
		yield return WaitOrQuit(bowl2time); // new WaitForSeconds(bowl2time);
		Fugu.ObjectUtils.DeactivateChildren(bowl2text);
		if (checkQuit()) {
			yield break;
		}
		state = "StateRoll";
	}

	// state to begin bonus ball
	IEnumerator StateBall3() {
		UAP_AccessibilityManager.Say("Bonus ball");
		RemoveDownedPins();
		ResetBall();
		if (GetPinsDown()==10) {
			ResetPins();
		}
		roll = 2;
		Play(bonusballtext);
		yield return WaitOrQuit(bonusballtime); // new WaitForSeconds(bonusballtime);
		Fugu.ObjectUtils.DeactivateChildren(bonusballtext);
		if (checkQuit()) {
			yield break;
		}
		state = "StateRoll";
	}

	// state to start rolling
	IEnumerator StateRoll() {
		if (checkQuit()) {
			yield break;
		} 
		StartRolling();
		state="StateRolling";
	}

	IEnumerator StateRolling() {
		//	var pinpos:Vector3 = pincenter.transform.position;
		UAP_AccessibilityManager.Say("The ball is rolling");
		while (true) {
				if (checkQuit()) {
				StopRolling();
				break;
			}
			if (timer && TimerPause.IsTimedOut()) {
				StopRolling();
				state = "StateShowTimeout";
				break;
			}
			if (GutterBall()) {
				StopRolling();
				state = "StateShowGutter";
				break;
			}
			if (Vector3.Distance(balltrans.position,pincenter)<pindistance) {
				StopRolling();
				state = "StateShowPins";
				break;
			}
			yield return null;
		}
	}

	// state to display the scoreboard
	IEnumerator StateShowScore() {
		ShowScoreBoard();
		yield return WaitOrQuit(scoretime);
		if (checkQuit())  {
			yield break;
		}
		if (frame == 9) {
			switch (roll) {
			case 0:
				state = "StateBall2";
				break;
			case 1:
				if (IsSpare(frame) || IsStrike(frame)) {
					state = "StateBall3";
				} else {
					if (++currentplayer < Game.numplayers) {
						UpdateName();
						state = "StateBowlFrame";
					} else {
						state = "StateGameOver";
					}
				}
				break;
			case 2:
				if (++currentplayer < Game.numplayers) {
					UpdateName();
					state = "StateBowlFrame";
				} else {
					state = "StateGameOver";
				}
					break;
				//	yield return true; // return true;
			}
		} else if (roll == 0 && !IsStrike(frame)) {
			state = "StateBall2";
		} else {
			if (++currentplayer < Game.numplayers) {
			} else {
				++frame;
				currentplayer = 0;
			}
			UpdateName();
			state = "StateBowlFrame";
		}
	}



	// show gutter text state
	IEnumerator StateShowGutter() {
		UAP_AccessibilityManager.Say("gutter ball!");
		UpdateScore();
		Play(gutter);
		yield return WaitOrQuit(guttertime);
		Fugu.ObjectUtils.DeactivateChildren(gutter);
		if (checkQuit()) {
			yield break;
		}
		state = "StateShowScore";
	}

	// show result of roll
	IEnumerator StateShowPins() {
		Fugu.ObjectUtils.ActivateChildren(pinstatus);
		yield return WaitOrQuit(pinsettletime);

		Fugu.ObjectUtils.DeactivateChildren(pinstatus);
			if (checkQuit()) {
				yield break;
			}
		UpdateScore();
		if (roll == 0 && IsStrike(frame)) {
			if (++numstrikes>maxstrikes) {
				maxstrikes = numstrikes;
				#if UNITY_IOS || UNITY_TVOS || P31_GPGS
				if (maxstrikes<GameCenter.strikeAchievements.Length+1) {
					Fugu.GameCenter.Achievement(GameCenter.strikeAchievements[maxstrikes-1],100);
				}
				#endif
			}
			state = "StateShowStrike";
				yield break; // return true; // return true;
		}
		numstrikes = 0;
		if (roll == 1 && IsSpare(frame)) {
			state = "StateShowSpare";
			yield break; // return true; // return true;
		}
		state = "StateShowScore";
	}

	IEnumerator StateShowStrike() {
		UAP_AccessibilityManager.Say("you got a strike!");
		Play(strike);
		yield return WaitOrQuit(striketime);
		Fugu.ObjectUtils.DeactivateChildren(strike);
		if (checkQuit()) {
			yield break;
		}
		state = "StateShowScore";
	}

	// show spare text state
	IEnumerator StateShowSpare() {
		UAP_AccessibilityManager.Say("you got a spare!");
		Play(spare);
		yield return WaitOrQuit(sparetime);
		Fugu.ObjectUtils.DeactivateChildren(spare);
		if (checkQuit()) {
			yield break;
		}
		state = "StateShowScore";
	}

	// state to show timeout message
	IEnumerator StateShowTimeout() {
		UAP_AccessibilityManager.Say("you're out of time");
		UpdateScore();
		Play(timeout);
		yield return WaitOrQuit(timeouttime);

		Fugu.ObjectUtils.DeactivateChildren(timeout);
		if (checkQuit()) {
			yield break;
		}
		state = "StateShowScore";
	}

	IEnumerator StateGameOver() {
		UAP_AccessibilityManager.Say("game over");
		Play(gameovertext);
		yield return WaitOrQuit(gameovertime);
		Fugu.ObjectUtils.DeactivateChildren(gameovertext);
		if (checkQuit()) {
			yield break;
		}
		state = "StateCloseGame";
	}

	// open/close wipe

	IEnumerator StateCloseGame() {
		nextLevel = "HyperTrophy";
		state = "WipeClose";
		yield return null;
	}

	override protected IEnumerator WipeClose() {
		PostScore();
		HideScoreBoard();
		yield return base.WipeClose();
	}


}
}