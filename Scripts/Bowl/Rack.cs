using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rack : MonoBehaviour {


/* Copyright (c) 2007 Technicat, LLC */

//import Fugu;

public GameObject pin;

public float distance = 1.0f;

public int rows = 4;

public float knockedAngle = 45.0f;

static public int knockedOver = 0;

private GameObject[] pins;

void Start () {
	pins = new GameObject[10];
	var offset = Vector3.zero;
	int i = 0;
	for (var row=0; row<rows; ++row) {
		offset.z+=distance;
		offset.x=-distance*row/2;
		for (var n=0; n<=row; ++n) {
			pins[i++]=Instantiate(pin, transform.position+offset, transform.rotation);
			offset.x+=distance;
		}
		
	}
}

void Update() {
	knockedOver = 0;
	foreach (GameObject pin in pins) {
		if (transform.localEulerAngles.x>knockedAngle ||
			pin.transform.localEulerAngles.z>knockedAngle) 
			++knockedOver;
		}
	}

void ResetPosition() {
/*for (var pin:Transform in pins) {
		var ball:Reset = pin.GetComponent(Reset);
		ball.ResetPosition();
	}  */
		var offset = Vector3.zero;
		var i = 0;
	for (var row=0; row<rows; ++row) {
		offset.z+=distance;
		offset.x=-distance*row/2;
		for (var n=0; n<=row; ++n) {
			var pin = pins[i++];
			pin.transform.position = transform.position+offset;
			pin.transform.rotation = transform.rotation;
			pin.GetComponent<Rigidbody>().velocity = Vector3.zero;
			pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			offset.x+=distance;
		}
		}

	knockedOver = 0;


}} 
