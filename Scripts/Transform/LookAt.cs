using UnityEngine;
using System.Collections;

namespace Fugu {
public class LookAt : MonoBehaviour {

	public	Transform target;

	void Start () {
		if (target != null) {
			transform.LookAt(target.position);
		}
	}
	}

}
