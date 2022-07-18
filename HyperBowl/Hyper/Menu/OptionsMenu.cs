using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Fugu {

public class OptionsMenu : MonoBehaviour {

	public GameObject main; // the pause menu

	void Update() {
		if ((Input.GetKeyDown("escape") || Input.GetKeyDown("menu"))) {
				ShowMain();
		}
	}

	public void ShowMain() {
		this.main.SetActive(true);
		gameObject.SetActive( false);
	}

	public void BowlForce(Slider slider) {
		Fugu.BowlForce.mousemult = slider.value;
	}

	} // end class
} // end namespace