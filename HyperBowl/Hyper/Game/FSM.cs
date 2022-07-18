using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Hyper {

abstract public class FSM : Fugu.FSM {

		private GameObject wipe = null;
		
		private float wipetime=1.0f;
		
		protected string nextLevel;

		protected GameObject buttons;
		
		// scene to return to when quitting - main menu or the lane
		static public string StartScene {
			get {
			#if HYPERCLASSIC
			return "HyperClassic";
			#endif 
			#if HYPERROME
			return "HyperRoman";
			#endif
			#if HYPERFOREST
			return "HyperForest";
			#endif
			#if HYPERSHIP
			return "HyperShip";
			#endif
			#if HYPERSF
			return "HyperSF";
			#endif
			#if HYPERTOKYO
			return "HyperTokyo";
			#endif
		/*	#if HYPERPENELOPE
			return "HyperPenelope";
			#endif
			#if HYPERSNOW
			return "HyperSnow";
			#endif
			#if HYPERMUSHROOM
			return "HyperMushroom";
			#endif
			#if HYPERCAMP
			return "HyperCamp";
			#endif */
			#if HYPERALL // && UNITY_TVOS
			string loadedLevelName = SceneManager.GetActiveScene().name;
			switch (loadedLevelName) {
				#if !UNITY_WEBGL
				case "HyperLogo":
				case "HyperSelect":
				return "HyperMenu";
				#endif
				default:
				return "HyperSelect";
			}
			#endif
			return "HyperMenu";
		}
		}

		protected GameObject ButtonCam {
			get {
				return buttons.transform.Find("buttoncam").gameObject;
			}
		}
		
		
		// callbacks

		virtual public void Awake () {
			wipe = GameObject.FindWithTag("Wipe");
			buttons = GameObject.FindWithTag("Buttons");
			state = "WipeReady";
		}
		
		// states

		// make sure we're out of launch screen before wiping
		virtual public IEnumerator WipeReady() {
			//while (Application.isShowingSplashScreen) {
				while (!SplashScreen.isFinished) {
				yield return null;
			}
			state = "WipeOpen";
		}

		// why is this not protected?
		virtual public IEnumerator WipeOpen() {
			Fugu.Platform.StopActivityIndicator();
			if (GetComponent<AudioSource>() != null) {
				GetComponent<AudioSource>().Play();
			}
			if (wipe != null) {
				wipe.BroadcastMessage("PlayOpen");
				yield return new WaitForSeconds(wipetime);
				Fugu.ObjectUtils.DeactivateChildren(wipe);
			}
			UAP_AccessibilityManager.Say(SceneManager.GetActiveScene().name);
		}
		
		virtual protected IEnumerator WipeClose() {
			if (GetComponent<AudioSource>() != null) {
				GetComponent<AudioSource>().Stop();
			}
			if (wipe != null) {
				Fugu.ObjectUtils.ActivateChildren(wipe);
				wipe.BroadcastMessage("PlayClose");
				yield return new WaitForSeconds(wipetime);
			}
		//	#if !UNITY_IPHONE
		//	if (nextLevel == null) {
		//		Application.Quit();
		//	} else
			//	#endif */
				Hyper.Quit.quitGame = false;
			//Debug.Log("Next level: "+nextLevel);
			LoadLevel(nextLevel);
		}
		
		static public void LoadLevel(string level) {
			Fugu.Platform.StartActivityIndicator();
			SceneManager.LoadScene(level);
		}
}

}
