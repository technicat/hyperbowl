﻿using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class CullBox : MonoBehaviour {

	public GameObject water;

public float front = 0;
public float left=1;
public float right =-1;

public bool waterVisible=false;

private Transform mytrans;

void Start() {
	mytrans = transform;
	if (water) {
		water.SetActive(waterVisible);
	}
}

void Update () {
	if (!waterVisible) {
		if (mytrans.position.z<front ||
			mytrans.position.x>left ||
			mytrans.position.x<right) {
			waterVisible = true;
			water.SetActive(true);
		}
	} else {
		if (mytrans.position.z>front &&
			mytrans.position.x<left &&
			mytrans.position.x>right) {
			waterVisible = false;
			water.SetActive(false);
		}
			}
		}
	}
}