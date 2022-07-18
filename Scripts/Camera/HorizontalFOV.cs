using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fugu {
	
public class HorizontalFOV : MonoBehaviour {

		public float hFOV = 30.0f;

	public void Start() {
			Camera camera = GetComponent<Camera>();
			float aspect = camera.aspect; //  (float)camera.height/(float)camera.
		//	camera.fieldOfView = 50.0f + 25.0f/aspect; // camera.fieldOfView/aspect;

			float hrad = hFOV*Mathf.Deg2Rad;
			float camH = Mathf.Tan(hrad*0.5f)/aspect;
			float  vrad = Mathf.Atan(camH)*2.0f;
			camera.fieldOfView = vrad * Mathf.Rad2Deg;
	}

}
}