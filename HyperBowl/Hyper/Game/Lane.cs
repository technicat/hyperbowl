/* Copyright (c) Technicat LLC */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Hyper {
public class Lane : FSM {

	public string laneName = "HyperBowl";

	public GameObject testBall;

	protected GameObject ball;
	protected GameObject timer;

	// enable/disable bowling control
	void BowlEnable(bool enable) {
		if (enable) {
			if (!ball.activeSelf) {
				ball.SetActive(true);
			}
			if (ball.GetComponent<Rigidbody>().isKinematic) {
				ball.GetComponent<Rigidbody>().isKinematic = false;
			}
			ball.SendMessage("StartRolling");
		} else {
			ball.SendMessage("StopRolling");
		}
	}

	// enable/disable camera following
	protected void FollowEnable(bool enable) {
		Behaviour follow = Camera.main.GetComponent("FollowBall") as Behaviour;
		follow.enabled = enable;
	}

	// start bowling in the lane, start the timer
	protected virtual void StartRolling() {
		Fugu.ObjectUtils.ActivateChildren(timer);
		BowlEnable(true);
	}

	// finish bowling in the lane, kill the timer
	protected virtual void StopRolling() {
		BowlEnable(false);
		FollowEnable(false);
		Fugu.ObjectUtils.DeactivateChildren(timer);
	}

	// callbacks

	override public void Awake () {
		base.Awake();
		var ballroot = GameObject.FindWithTag("BallRoot");
		if (ballroot == null) {
			ballroot = new GameObject();
			ballroot.tag = "BallRoot";
		}
		var ballpos = GameObject.FindWithTag("BallPos");
		ballroot.transform.parent = ballpos.transform;
		ballroot.transform.localPosition = Vector3.zero;
		ball = Fugu.ObjectUtils.GetChild(ballroot);
		// in the Editor, instantiate the ball if we're starting directly on the lane
		#if UNITY_EDITOR
		if (ball == null) {
			ball = Instantiate(testBall,Vector3.zero,Quaternion.identity) as GameObject;
			ball.transform.parent = ballroot.transform;
		}
		#endif
		ball.transform.localPosition = Vector3.zero;
		ball.SetActive(true);
		ball.SendMessage("SetPosition");
		ball.SendMessage("ResetPosition");
		ball.GetComponent<Rigidbody>().isKinematic = true;
		timer = GameObject.FindWithTag("Timer");
		Fugu.Platform.LockCursor();
	}

	override public void Start () {
		System.GC.Collect();
		base.Start();
	}

	// states

		override public IEnumerator WipeOpen() {
		yield return base.WipeOpen();
	}

	override protected IEnumerator WipeClose() {
		StopRolling();
		ball.GetComponent<AudioSource>().Stop();
		var persist = GameObject.FindGameObjectWithTag("PersistRoot");
			if (persist != null) {
				ball.transform.parent.parent = persist.transform; // detach ballroot
			} else {
				Fugu.Log.Warn("couldn't find PersistRoot");
			}
		yield return base.WipeClose();
	}

// could merge this with checkQuit?
		void StateQuitGame() {
			if (
				SceneManager.GetActiveScene().name == "HyperSelect"
				//Application.loadedLevelName == "HyperSelect"
			) {
				nextLevel = "HyperMenu";
			} else {
				nextLevel = StartScene;
			}
			state = "WipeClose";
			#if HYPER_ADS
			Fugu.Ads.ShowAd();
			#endif
		}

	

		// substitute for WaitForSeconds
		// or this could be a state?
		protected IEnumerator WaitOrQuit(float delay) {
			float timer = Time.time + delay;
			while (Time.time < timer) {
				if  (Quit.quitGame) {
					yield break;
				} 
				yield return null;
			}
		}

// rename IsQuitting?
		protected bool checkQuit() {
			if (Quit.quitGame) {
				state = "StateQuitGame";
				return true;
			} 
			return false;
		}
}
}