using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fugu {
sealed public class CollisionSound : MonoBehaviour {
	
	// other physic materials we might collide against
	public PhysicMaterial[] physmats;
	public AudioClip[] sounds;
		
	private Dictionary<PhysicMaterial,AudioClip> soundTable;


	private const float minbounce = 1f;
	private const float collisionScale = 1f;

	private const float minsound = 0.2f;
	private const float maxsound = 1.0f;
		
	private const float rollNormalY = 0.5f; // roll sound and effects on flat surfaces

	private Transform trans = null;

	void Awake () {
		trans = transform;
		//clips = new PoolingSystem<GameObject>(clipPrefab,poolSize);
		soundTable = new Dictionary<PhysicMaterial,AudioClip>();
		for (int i=0; i<physmats.Length; ++i) {
			soundTable[physmats[i]]=sounds[i];
		}
		InitAudioPool();
	}
		
	void OnCollisionEnter(Collision collision) {
		//Debug.Log("contacted "+collider.gameObject.name);
		//	var speed:float = collider.relativeVelocity.sqrMagnitude;
			//if (collision.contacts.Length>1) { // when is this zero?
		float speed = collision.contacts.Length==0 ? 1.0f : Vector3.Dot(collision.relativeVelocity,collision.contacts[0].normal);
		if (speed>minbounce) {
			AudioClip sound=null;
			PhysicMaterial mat = collision.collider.sharedMaterial;
			if (mat != null) {
				soundTable.TryGetValue (mat,out sound);
			}
			if  (sound != null) {
				float vol = Mathf.Max(minsound,Mathf.Min(maxsound,collisionScale*speed));
				// avoid interfering with rolling sound
				PlayClipAtPoint(sound,trans.position,vol);
			}
	}
}

static private GameObject[] audiopool;
static int audiopoolindex = 0;
		
static void InitAudioPool() {
		if (audiopool == null) {
				audiopool = new GameObject[50];
				for (int i=0; i<audiopool.Length; ++i) {
					GameObject go = new GameObject("audio pool");
					go.AddComponent<AudioSource>();
					AudioSource source = (AudioSource)(go.GetComponent<AudioSource>());
					source.minDistance = 990;
					source.maxDistance = 1000;
					source.priority = 255;
					audiopool[i]=go;
					Object.DontDestroyOnLoad(go);
				}
			}
		}
		
static public void PlayClipAtPoint (AudioClip clip, Vector3 position, float volume) {
	GameObject go = audiopool[audiopoolindex];
	go.transform.position = position;
	AudioSource source = (AudioSource)(go.GetComponent<AudioSource>());
	source.clip = clip;
	source.volume = volume;
	source.Play ();
	if (++audiopoolindex==audiopool.Length) {
		audiopoolindex = 0;
	}
}


}
}