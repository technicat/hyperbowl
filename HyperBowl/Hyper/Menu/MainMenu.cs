using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Fugu {
public class MainMenu : MonoBehaviour {

	public GameObject options; // the pause menu


	void Start () {
			
}

void Update() {
	if ((Input.GetKeyDown("escape") || Input.GetKeyDown("menu"))) {
				Unpause();
	}
}

		public void ShowOptions() {
			this.options.SetActive(true);
			gameObject.SetActive( false);
		}

		public void Unpause() {
			PauseMenu.UnPauseGame();
		}

}
}