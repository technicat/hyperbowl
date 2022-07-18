using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuRadioGroup : MonoBehaviour {

	private GameObject onButton = null;
	private GameObject offButton = null;

	void SetOnButton (GameObject button) {
		// make sureprevious on button is off
		if (onButton != null) {
			onButton.SetActive(false);
		}
		onButton = button;
	}

	void SetOffButton (GameObject button) {
		// make sure previous off button is on
		if (offButton != null) {
			offButton.SetActive(true);
		}
		offButton = button;
	}

}
}