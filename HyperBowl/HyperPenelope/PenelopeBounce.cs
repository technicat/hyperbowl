using UnityEngine;
using System.Collections;

namespace Hyper {
public class PenelopeBounce : MonoBehaviour {
		
	public ParticleSystem shockwave;

	private Vector3 force = new Vector3(0,10000,0);
	private AudioSource sound = null;
		
	void Awake() {
			sound = GetComponent<AudioSource>();
	}
		
	void OnTriggerEnter (Collider collision) { Debug.Log ("bounce!");
		collision.gameObject.GetComponent<Rigidbody>().AddForce(force);
		if (sound != null)	{
			sound.Play();
			}
		if (shockwave != null) {
			shockwave.GetComponent<ParticleSystem>().Play();
		}
	}
		
	
}
}