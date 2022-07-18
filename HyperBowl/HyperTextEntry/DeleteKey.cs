using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class DeleteKey : MonoBehaviour {

	
public GameObject highlightKey;


#if !UNITY_IPHONE && !UNITY_ANDROID
void OnMouseEnter () {
highlightKey.SetActive(true);
GetComponent<AudioSource>().Play();
}

void OnMouseExit() {
highlightKey.SetActive(false);
}
#endif

#if UNITY_IPHONE || UNITY_ANDROID
void OnButtonDown
#else
void OnMouseDown
#endif
() {
	if (Key.entry.Length>0) {
		Key.entry = Key.entry.Substring(0,Key.entry.Length-1);
		GetComponent<AudioSource>().Play();
	}
}
	}
}