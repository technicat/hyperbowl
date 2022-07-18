using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hyper {
sealed public class BallParticleSystem : MonoBehaviour {
	
	// other physic materials we might collide against
	public PhysicMaterial[] physmats;
	public GameObject[] particles;
		
	private Dictionary<PhysicMaterial,GameObject> particleTable;

	private const float slowspeed = 1f;

	private const float collisionScale = 1f;
		
	private const float rollNormalY = 0.5f; // roll sound and effects on flat surfaces

	private GameObject partSys = null;

	void Awake () {
		particleTable = new Dictionary<PhysicMaterial,GameObject>();
		for (int i=0; i<physmats.Length; ++i) {
			particleTable[physmats[i]]=particles[i];
		}
	}

void OnCollisionStay (Collision collision) {
	if (collision.contacts.Length>0 && collision.contacts[0].normal.y>rollNormalY) {
		GameObject parts = null;
		PhysicMaterial mat = collision.collider.sharedMaterial;
		if (mat != null) {
			particleTable.TryGetValue (mat,out parts);
		}
		if (partSys != parts) {
			partSys = parts;
		}
		float speed = collision.relativeVelocity.sqrMagnitude;
		if (speed>slowspeed) {
			if (partSys != null) {
				partSys.transform.position = collision.contacts[0].point;
					}
			StartEffect();
		} else {
			StopEffect();
		}
	}
}

void ResetPosition() {
	StopEffect ();
}

void StartEffect() {
	if (partSys != null) {
		if (!partSys.activeSelf) {
			partSys.SetActive (true);
		}
		if (!partSys.GetComponent<ParticleSystem>().isPlaying) {
			partSys.GetComponent<ParticleSystem>().Play ();
		}
	}
}
		
void StopEffect() {
	if (partSys != null) {
		partSys.GetComponent<ParticleSystem>().Stop();
	}
}

void OnCollisionExit(Collision collider) {
	StopEffect ();
}


}
}