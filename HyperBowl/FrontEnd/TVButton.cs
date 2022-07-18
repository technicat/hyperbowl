// Copyright 2017 Technicat LLC

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

#if UNITY_TVOS
using InControl;
#endif

//  tap-for-button-press detection on TVOS
// have just one of these in a scene

namespace Hyper {
public class TVButton : MonoBehaviour {

		#if UNITY_TVOS
		public void Update
		() {
		/*	if (Input.GetButtonDown("joystick button 14")) {
				this.gameObject.SendMessage("OnButtonDown");
			} */
			var inputDevice = InputManager.ActiveDevice;
			if ( inputDevice.Action1.WasPressed) {
				this.gameObject.SendMessage("OnButtonDown");
			}
	/*	for (int i = 0; i < Input.touchCount; ++i) {
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began) {
					this.gameObject.SendMessage("OnButtonDown");
					break;
				}
			} */
		} 
		#endif
	
}
}