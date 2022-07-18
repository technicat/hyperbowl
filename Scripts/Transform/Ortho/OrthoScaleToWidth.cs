﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// scale gameObject to fit ortho camera width
// assume localScale is correct for a square aspect ratio
public class OrthoScaleToWidth : MonoBehaviour {

	//float scale = 0.008f;

	// Use this for initialization
	void Start () {
		Camera camera = Camera.main; // assume that any old camera will do
		//float aspect = (float)Screen.height/(float)Screen.width;
		//float aspect = camera.aspect; //  (float)camera.height/(float)camera.
		float aspect = camera.aspect; // (float)camera.pixelWidth/(float)camera.pixelHeight;
		transform.localScale = new Vector3( transform.localScale.x * aspect, transform.localScale.y * aspect, transform.localScale.z);
	}
	

}
