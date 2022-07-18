using UnityEngine;
using System.Collections;

namespace Hyper {
public class ScrollText : MonoBehaviour {
	
	private Transform trans;
	private float inc = 0.1f;
	public float end = -3.0f;
		
	void Awake() {
		trans = transform;
	}
		
	// Update is called once per frame
	void Update () {
		if (trans.localPosition.x < end) {
			gameObject.SendMessage("ResetPosition");
			} {
			trans.localPosition = new Vector3(trans.localPosition.x-inc*Time.deltaTime,trans.localPosition.y,trans.localPosition.z);
			}
		}
	}
}