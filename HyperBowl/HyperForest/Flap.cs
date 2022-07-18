using UnityEngine;
using System.Collections;

namespace Hyper {
public class Flap : MonoBehaviour {
		
	/* rock along z-axis */

	public float speed=0.2f;
	public float rockness=30.0f;

	

	void Update () {
			Vector3 rot = new Vector3(transform.localEulerAngles.x,
				transform.localEulerAngles.y,
				Mathf.Sin(Time.time*speed)*rockness);
			transform.localEulerAngles = rot;
	}
}
}