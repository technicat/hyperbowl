using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class BallTextAnim : MonoBehaviour {
		
	private Hashtable ht;
	private Transform trans;

	// Use this for initialization
	void Awake () {
		ht=iTween.Hash("x",0,"time",0.5,"easetype",iTween.EaseType.easeOutQuad);
		trans = transform;
	}
	
	void Play() {
		Reset();
		iTween.MoveTo(gameObject,ht);
}

	void Reset() {
		trans.position = new Vector3(1,trans.position.y, trans.position.z);
	}

	
	
	}
}
