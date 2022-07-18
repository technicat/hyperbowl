using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class GameOverTextAnim : MonoBehaviour {

		private float orig;

		private Hashtable hash;

void Awake ()
{
	orig = transform.position.z;
	hash = iTween.Hash("z",orig,"speed",2,"easetype",iTween.EaseType.easeOutQuad);
	Reset();
}

void Reset() {
			Vector3 pos = new Vector3(transform.position.x, transform.position.y, 1);
			transform.position = pos;
}

void Play() {
	Reset();
	iTween.MoveTo(gameObject, hash);
}
	}
}
