using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hyper {
sealed public class BallRollSound : MonoBehaviour {

		public AudioClip defaultSound;
	
	// other physic materials we might collide against
	public PhysicMaterial[] physmats;
	public AudioClip[] rollSounds;
		
	private Dictionary<PhysicMaterial,AudioClip> rollSoundTable;

	private const float slowspeed = 1f;

	private const float rollVolume = 0.1f;

	private const float minbounce = 1f;
	private const float collisionScale = 1f;

	private const float minsound = 0.2f;
	private const float maxsound = 1.0f;
		
	private const float rollNormalY = 0.5f; // roll sound and effects on flat surfaces

	private AudioSource audiosource = null;

	void Awake () {
		audiosource = GetComponent<AudioSource>();
		rollSoundTable = new Dictionary<PhysicMaterial,AudioClip>();
		for (int i=0; i<physmats.Length; ++i) {
			rollSoundTable[physmats[i]]=rollSounds[i];
		}
	}

void OnCollisionStay (Collision collision) {
			// hack for contacts
	if (collision.contacts.Length== 0 || collision.contacts[0].normal.y>rollNormalY) {
		AudioClip sound = null;
		PhysicMaterial mat = collision.collider.sharedMaterial;
		if (mat != null) {
			rollSoundTable.TryGetValue (mat,out sound);
		}
		if (sound == null) {
					sound = defaultSound;
				}
		if (audiosource.clip != sound) {
			//audiosource.Stop(); // necessary when we change clips?
			audiosource.clip = sound;
			//	audiosource.Play();
		}
		float speed = collision.relativeVelocity.sqrMagnitude;
		if (speed>slowspeed) {
			audiosource.volume = Mathf.Min(1.0f,speed*rollVolume); // adjust volume based on speed
			StartSound();
		} else {
			StopSound ();
		}
	}
}

void ResetPosition() {
	StopSound ();
}

void StartSound() {
	if (!audiosource.isPlaying && audiosource.clip != null) {
		audiosource.Play ();
	}
}
		
void StopSound() {
	audiosource.volume = 0.0f; // seems to work better than Stop
}

void OnCollisionExit(Collision collider) {
	StopSound ();
}


}
}