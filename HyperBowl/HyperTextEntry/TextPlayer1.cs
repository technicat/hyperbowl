using UnityEngine;
using System.Collections;

namespace Hyper {
public class TextPlayer1 : MonoBehaviour {

	

	private TextMesh text3d;

	

	void Start () {
			text3d = GetComponent<TextMesh>();
	}

	void Update () {
		if (text3d.text != Key.entry) {
			text3d.text = Key.entry;
			//		audio.Play();
		}
	}

}
}