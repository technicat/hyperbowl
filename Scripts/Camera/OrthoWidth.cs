using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fugu {
	
public class OrthoWidth : MonoBehaviour {

		//public float narrowWidth = 35;
	public float phoneWidth =  35;
	public float tabletWidth =  40;

	public void Start() {
			Camera camera = GetComponent<Camera>();
			//float aspect = (float)Screen.height/(float)Screen.width;
			//float aspect = camera.aspect; //  (float)camera.height/(float)camera.
			float aspect = (float)camera.pixelWidth/(float)camera.pixelHeight;
			float tabletAspect = 3.0f/4.0f;
		/*	float iPhone8Aspect = 750.0f/1334.0f;
		 float iPhoneZAspect = 11250f/2436.0f;
			if (aspect <  iPhone8Aspect-1.0f/16.0f)  {
				camera.orthographicSize = narrowWidth / aspect;
				return;
			} */
			if (aspect <  tabletAspect-1.0f/16.0f)  {
				camera.orthographicSize = phoneWidth / aspect;
				return;
			}
			camera.orthographicSize = tabletWidth / aspect;
	}

}
}