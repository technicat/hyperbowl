using UnityEngine;
using System.Collections;
/*
namespace Hyper {
	
public class BallParticles : MonoBehaviour {

// bowling ball rolling sound

// other physic materials we might collide against
		public  PhysicMaterial[] physmats;
		public GameObject[] rollParticles;

private float slowspeed = 1f;

//private Transform trans;
private GameObject parts;


void Start() {
	trans = transform;
}

void OnCollisionStay (Collision collider) {
	for (int i = 0; i<physmats.Length; ++i) {
		if (collider.collider.sharedMaterial == physmats[i]) {
			if (parts != rollParticles[i]) {
				parts = rollParticles[i];
			}
			float speed = collider.relativeVelocity.sqrMagnitude;
			ContactPoint contact = collider.contacts[0];
			if (!parts.GetComponent<ParticleSystem>().isPlaying) {
				if (speed>slowspeed && contact.normal.y>.5) {
					StartParticles();
				}
			} else {
				if (speed<slowspeed) {
					PauseParticles();
				}
			}
			if (parts != null) {
				parts.transform.position = contact.point;
			}
			return;
		}
	}
	StopParticles();
}

void ResetPosition() {
	StopParticles();
}

void OnCollisionExit(Collision collider) {
	StopParticles();
}

void StopParticles() {
	if (parts != null) {
		parts.GetComponent<ParticleSystem>().Stop();
		parts = null;
	}
}

void PauseParticles() {
	if (parts != null) {
		parts.GetComponent<ParticleSystem>().Stop();
	}
}


void StartParticles() {
	if (parts != null) {
		parts.GetComponent<ParticleSystem>().Play();
	}
}
	}
}

*/