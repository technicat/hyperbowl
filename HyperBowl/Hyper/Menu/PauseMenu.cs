using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

#if INCONTROL
using InControl;
#endif

#if LEANTOUCH
using Lean.Touch;
#endif

namespace Fugu {
public class PauseMenu : MonoBehaviour {
		
	public bool startPaused = true;

	static GameObject gui; // the pause menu
		
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA
	static bool savedCursor = true;
#endif

	void Start () {
		//	Debug.Log ("PauseMenu is on "+gameObject.name);
//#if UNITY_IPHONE || UNITY_ANDROID
//  FingerGestures.OnPinchEnd += OnGesturePinchEnd;
//#endif
	gui = GameObject.FindWithTag("GUI");
//}

//void Start() {
	if (startPaused) {
		PauseGame();
	} else {
		UnPauseGame();
	}
}

void Update() {
			#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA || UNITY_ANDROID || UNITY_EDITOR
	if ((Input.GetKeyDown("escape") || Input.GetKeyDown("menu"))) {
		PauseGame();
	}
	#endif
			#if INCONTROL && UNITY_TVOS
			var inputDevice = InputManager.ActiveDevice;
			if ( inputDevice.Action2.WasPressed) {
			//	PauseGame();
			}
			#endif
			#if LEANTOUCH
			// Get the fingers we want to use
			var fingers = LeanTouch.GetFingers(true, 2);

			// Scale the current value based on the pinch ratio
			var ratio = LeanGesture.GetPinchScale(fingers, 0.0f);
			if (ratio>1) {
				PauseGame();
			}
			#endif
/*	#if ICADE
	if (HyperiCade.ButtonPressed()) {
		PauseGame();
	}
	#endif */
}

// static functions

static public void PauseGame() {
#if UNITY_IOS
			string loadedLevelName = SceneManager.GetActiveScene().name;
	if (loadedLevelName == "HyperLogo" ||
	    loadedLevelName == "HyperMenu" ||
	    loadedLevelName == "HyperPayment" ||
	    loadedLevelName == "HyperTextEntry" ||
	    loadedLevelName == "HyperTrophy") return;
#endif
	if (gui != null) {
#if FINGER_GESTURES
		if (FingerGestures.Instance) {
			FingerGestures.Instance.enabled=false;
		}
#endif
		Time.timeScale = 0.0f;
			//	AudioListener.volume = 0.0f;
				AudioListener.pause = true;
		gui.SetActive(true);
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA
		savedCursor = Cursor.visible;
		//Screen.lockCursor = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
#endif
	}
}

static public void UnPauseGame() {
	if (gui != null) {
#if FINGER_GESTURES
		if (FingerGestures.Instance) {
			FingerGestures.Instance.enabled=true;
		}
#endif
		Time.timeScale = 1.0f;
				AudioListener.pause = false;
				//AudioListener.volume = 1.0f;
		gui.SetActive(false);
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA
		//Screen.lockCursor = savedCursor;
		Cursor.visible = savedCursor;
		if (!savedCursor) {
			Cursor.lockState = CursorLockMode.Locked;
		} else {
					Cursor.lockState = CursorLockMode.None;
				}
#endif
	}
}

// pause events

#if FINGER_GESTURES
void OnPinch(PinchGesture gesture) {
	if (gesture.Phase == ContinuousGesturePhase.Ended) {
		PauseGame();
	}
}
#endif
}
}
