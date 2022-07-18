using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class Rock : MonoBehaviour {

		private Hashtable path;

		void Awake() {
			path=iTween.Hash("z",30,"time",10,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.easeInOutSine);
		}

		void Start() {
			Vector3 angles = new Vector3(transform.eulerAngles.x,
				transform.eulerAngles.y,
				-30);
			transform.eulerAngles = angles;
			iTween.RotateTo(gameObject,path);
		}

}
}
