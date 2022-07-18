using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class Menu : FrontEnd {

		static public string finalstate; // actually, the next to final state

		static public string desturl;

		static public GameObject onButton; // currentlyly on button
		static public GameObject offButton;

		private string restartState = "WipeOpen";

	override public void Awake () {
			base.Awake();
			desturl = null;
			finalstate=null;
			Bowl.currentplayer = 0;
		}



		override protected IEnumerator WaitForButton() {
			yield return base.WaitForButton();

			state = finalstate;
		}

		void NextPage() {
			Fugu.Platform.OpenWebPage(desturl);
			state = restartState;
		}


		void NextYouTube() {
			Fugu.Platform.OpenYouTube(desturl);
			state = restartState;
		}

		void NextAppStore() {
			Fugu.Platform.OpenWebPage(desturl);
			state = restartState;
		}

		void HighScore() {
		//	#if UNITY_IPHONE || UNITY_ANDROID
			Fugu.GameCenter.ShowLeaderboard();
		//	#endif

			state = restartState;
		/*	#if !UNITY_ANDROID && !UNITY_IPHONE
			Bowl.LoadLevel("HyperPeople");
			state = null;
			#endif */
		}


		void Achievements() {
			Fugu.GameCenter.ShowAchievements();
			state=restartState;
		}


		void Arcade() {
			Game.numplayers = 1;
			Game.mode = Game.Mode.ARCADE;
			nextLevel = "HyperPayment";
			state = "WipeClose";
		}

		void PlaySinglePlayer() {
			state = "WipeClose";
			Game.numplayers = 1;
			#if UNITY_IOS || UNITY_TVOS || STEAM || GPGS
			Game.mode = Game.Mode.GAMECENTER;
			nextLevel = "HyperSelect";
			return;
			#endif
			#if !UNITY_IOS && !STEAM && !UNITY_TVOS || !GPGS
			Game.mode = Game.Mode.ARCADE;
			nextLevel = "HyperTextEntry";
			return;
			#endif
		}

		//#if UNITY_STANDALONE || UNITY_ANDROID
		void StateQuit() {
		state="WipeClose";
		nextLevel = null;
		}
		//#endif


	} 


} 

