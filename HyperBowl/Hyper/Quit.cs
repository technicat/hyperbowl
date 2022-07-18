using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Hyper {

public class Quit : MonoBehaviour {

		static public bool quitGame = false;

		void Start () {
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		public void OnSceneLoaded(Scene scene, LoadSceneMode m) {
			quitGame = false;
		}
		/*
		public void OnLevelWasLoaded() {
			quitGame = false;
		} */

		// this is actually restart game
		public void OnPress(bool pressed) {
			if (pressed) {
				QuitGame();
			}
		}

		public void QuitGame() {
			quitGame = true;
			string loadedLevelName = SceneManager.GetActiveScene().name;
			if (loadedLevelName == "HyperLogo" ||
				loadedLevelName == "HyperMenu" ||
				loadedLevelName == "HyperPayment" ||
				loadedLevelName == "HyperTextEntry" ||
				loadedLevelName == "HyperTrophy")  {
				Application.Quit();
			}
		}

}

}
