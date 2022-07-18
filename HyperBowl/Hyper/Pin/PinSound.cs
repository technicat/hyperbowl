using UnityEngine;
using System.Collections;

namespace Hyper {

public class PinSound : MonoBehaviour {
	
		public AudioClip[] pinSound;
		public AudioClip[] fallSound;
		
		private float collisionScale = 5.0f;
		private float minBounce=1.0f;
//		private float minSound = 1.0f;
//		private float maxSound = 1.0f;
		
		void OnCollisionEnter(Collision collision) {
			float speed = collision.relativeVelocity.sqrMagnitude;
			//	var speed:float = Vector3.Dot(collision.relativeVelocity,collision.contacts[0].normal);
			if (speed>minBounce) {
				AudioClip sound;
				float loud = speed*collisionScale;
				//float load = Mathf.Max(loud, minSound);
//				float load = Mathf.Min(loud, maxSound);
				// check if hitting another pin - Pins layer
				if (collision.gameObject.layer == 29) {
					if (collision.gameObject.GetInstanceID()<gameObject.GetInstanceID()) {
						sound = pinSound[Random.Range(0,pinSound.Length)];
						Fugu.CollisionSound.PlayClipAtPoint(sound,transform.position,loud);
					}
				}
				else if (collision.gameObject.tag  != "Ball") {
					sound = fallSound[Random.Range(0,fallSound.Length)];
					Fugu.CollisionSound.PlayClipAtPoint(sound,transform.position,loud);
				}
			}
		}
}

}
