using UnityEngine;
using System.Collections;

namespace Hyper {

public class Wipe : MonoBehaviour {

		public AudioClip openSound;

		public AudioClip closeSound;

		void PlayOpen () {
			if (openSound != null) {
				GetComponent<AudioSource>().PlayOneShot(openSound);
			}
		}

		void PlayClose () {
			if (closeSound != null) {
				GetComponent<AudioSource>().PlayOneShot(closeSound);
			}
		}

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	} */
}

}


/*
 * 
 * var openSound:AudioClip;
var closeSound:AudioClip;

function PlayOpen () {
	if (openSound != null) {
		GetComponent.<AudioSource>().PlayOneShot(openSound);
	}
}

function PlayClose () {
	if (closeSound != null) {
		GetComponent.<AudioSource>().PlayOneShot(closeSound);
	}
}
*/