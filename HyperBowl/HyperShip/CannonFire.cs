using UnityEngine;
using System.Collections;

namespace Hyper {
public class CannonFire : MonoBehaviour {

		public ParticleSystem shockwave;

		private float minbounce = 1; // same as sound

		void OnCollisionEnter (Collision collider) {
			GetComponent<AudioSource>().Play();
			float speed = Vector3.Dot(collider.relativeVelocity,collider.contacts[0].normal);
			if (speed>minbounce) {
				shockwave.GetComponent<ParticleSystem>().Play();
			}
		}


	}
}