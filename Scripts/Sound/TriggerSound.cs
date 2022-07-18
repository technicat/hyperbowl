using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {



	// trigger sound
	// e,g, splash sound for water
	
	public AudioClip clip;
	
	public void OnTriggerEnter(Collider collider) {
		//	AudioSource.PlayClipAtPoint(clip, collider.transform.position);
		PlayClipAtPoint(clip, collider.transform.position, 1.0f);
	}
	
	public void PlayClipAtPoint (AudioClip clip, Vector3 position, float volume) {
		var go = new GameObject ("One shot audio");
		go.transform.position = position;
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.minDistance = 1000;
		source.maxDistance = 1000;
		source.Play ();
		Destroy (go, clip.length);
	}

}
