using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class CometAnim : MonoBehaviour {

	
	public Vector3 startPos;

	

	void Start() {
		Play();
	}

	void Play() {
		Vector3 orig = transform.position;
		transform.position = startPos;
			iTween.MoveTo(gameObject,iTween.Hash("delay",5,"position",orig,"time",10,"looptype",iTween.LoopType.loop));
	}

	}


}