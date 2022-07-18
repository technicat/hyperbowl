using UnityEngine;
using System.Collections;

namespace Hyper {
public class FlowerBounce : MonoBehaviour {

	
public ParticleSystem shockwave;

private Vector3 force = new Vector3(0,10000,0);

void OnCollisionEnter (Collision collision) {
	collision.gameObject.GetComponent<Rigidbody>().AddForce(force);
	GetComponent<AudioSource>().Play();
	shockwave.GetComponent<ParticleSystem>().Play();
}
	}
}