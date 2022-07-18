using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class Key : MonoBehaviour {

	public GameObject highlightKey;

	public string key="";

	private int maxtext = 10;

	static public string entry="";

	//  highlight key disabled for now

	#if !UNITY_IPHONE && !UNITY_ANDROID
	void OnMouseEnter () {
			if (highlightKey != null) {
	//	highlightKey.SetActive(true);
	//GetComponent<AudioSource>().Play();
			}
	}

	void OnMouseExit() {
			if (highlightKey != null) {
		//	highlightKey.SetActive(false);
			}
	}
	#endif

	#if UNITY_IPHONE || UNITY_ANDROID
	void OnButtonDown
	#else
	void OnMouseDown
	#endif
	() {
		if (entry.Length<maxtext) {
			entry += key;
			GetComponent<AudioSource>().Play();
		}
		}
	}
}