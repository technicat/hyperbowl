using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fugu {

// scale gameObject to fit ortho camera width
public class ScaleWidthToAspect : MonoBehaviour {

	public float refAspect = 0.75f; // aspect ratio that this object was designed for

	void Start () {
		Camera camera = Camera.main; // assume that any old camera will do
		float aspect = camera.aspect/refAspect;
		transform.localScale = new Vector3( transform.localScale.x * aspect, 
											transform.localScale.y, 
											transform.localScale.z);
	}
}
	

}
