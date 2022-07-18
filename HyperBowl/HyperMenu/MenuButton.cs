using UnityEngine;
using System.Collections;

namespace Hyper {

public class MenuButton : MonoBehaviour {

	

	// HyperBowl menu buttons
	// attach to off button
	// only off button has a collider so this handles all mouse events

	public GameObject highlightKey;
	public GameObject downKey; // on button

	public GameObject radiogroup;

	public bool defaultOn=false;


	void Start () {
		if (defaultOn) {
			downKey.SetActive(false); // hack to force OnEnable call
			GetComponent<Renderer>().enabled = false;
			SendMessage("ButtonDown");
		} else {
			downKey.SetActive(false);
			highlightKey.SetActive(false);
			GetComponent<Renderer>().enabled = true;
		}
	}
	#if UNITY_EDITOR || UNITY_STANDALONE
	void OnMouseEnter () {
		highlightKey.SetActive(true);
		GetComponent<Renderer>().enabled = false;
		GetComponent<AudioSource>().Play();
	}

	void OnMouseExit() {
		highlightKey.SetActive(false);
		GetComponent<Renderer>().enabled = true;
	}
	#endif

	void OnEnable() {
		GetComponent<Renderer>().enabled = true;
	}

	public void ButtonDown () {
		highlightKey.SetActive(false);
		downKey.SetActive(true);
		gameObject.SetActive(false);
		radiogroup.SendMessage("SetOnButton",downKey);
		radiogroup.SendMessage("SetOffButton",gameObject);
	}

	#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
	void OnButtonDown
	#else
	void OnMouseDown
	#endif
	() {
		radiogroup.GetComponent<AudioSource>().Play();
		SendMessage("ButtonDown");
	}


}
}