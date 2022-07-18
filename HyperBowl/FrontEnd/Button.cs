/* Copyright (c) Technicat LLC */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Handle menu (arcade) screen buttons
// attach to button collider
namespace Hyper {
public class Button : MonoBehaviour {

		static public bool buttonpressed = false;
		
		static public void ClearButtons() {
			buttonpressed = false;
		}

		public void Start()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		public void OnSceneLoaded(Scene scene, LoadSceneMode m) {
			ClearButtons();
			if (UAP_AccessibilityManager.IsEnabled()) {
				UAP_AccessibilityManager.Say("Tap to continue");
			}
		}
		
		#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL || UNITY_WSA
		public void OnMouseDown
		() {
			OnButtonDown();
		}
		#endif

		void Update () {
			if (UAP_AccessibilityManager.IsEnabled()) {
			if (Time.timeScale !=0) {
				for (int i = 0; i < Input.touchCount; ++i) {
					Touch touch = Input.GetTouch(i);
					if (touch.phase == TouchPhase.Began) {
							OnButtonDown();
					}
				}
				}
			}
		}
		
		public void OnButtonDown
		() {
			buttonpressed = true;
			Debug.Log("button pressed");
		}
		
		// make sure buttons are cleared at beginning of each scene
/*	public void OnLevelWasLoaded() {
			ClearButtons();
		} */

		#if P31_ICADE
		public void Update() {
			if (Hyper.iCade.ButtonPressed()) {
				buttonpressed = true;
			}
		}
		#endif

	
}
}