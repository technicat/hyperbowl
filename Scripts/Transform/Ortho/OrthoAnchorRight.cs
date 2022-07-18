using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  anchor gameObject to bottom
// assume localPositionis correct for a square aspect ratio
public class OrthoAnchorRight: MonoBehaviour {

	//float scale = 0.008f;

	// Use this for initialization
	void Start () {
		Camera camera = Camera.main; // assume that any old camera will do
		//float aspect = (float)Screen.height/(float)Screen.width;
		//float aspect = camera.aspect; //  (float)camera.height/(float)camera.
		float aspect = camera.aspect; //  (float)camera.pixelWidth/(float)camera.pixelHeight;
		//float dist = 0.1f; // transform.localPosition.y + 0.5f-0.1f; //  - ortho/2
		//float offset = dist * (1.0f/aspect-1.0f); // aspect * 0.8f;
//		float offset = (1.0f-transform.localPosition.x)/aspect;
		transform.localPosition = new Vector3(transform.localPosition.x*aspect, transform.localPosition.y, transform.localPosition.z);
	}
	

}
