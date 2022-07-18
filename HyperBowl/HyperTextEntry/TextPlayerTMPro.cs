using UnityEngine;
using System.Collections;

using TMPro;

namespace Hyper {
public class TextPlayerTMPro: MonoBehaviour {

	private TMP_Text text3d;

	void Start () {
			text3d = GetComponent<TMP_Text>();
	}

	void Update () {
		if (text3d.text != Key.entry) {
			text3d.text = Key.entry;
			//		audio.Play();
		}
	}

}
}