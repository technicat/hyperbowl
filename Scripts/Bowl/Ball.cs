using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

public float sunk = -100;

private Vector3 startPos;
private Vector3 startRot;

void Awake() {
	startPos = transform.localPosition;
	startRot = transform.localEulerAngles;
}

public void ResetPosition() {
	transform.localPosition = startPos;
	transform.localEulerAngles = startRot;
	if (GetComponent<Rigidbody>() != null) {
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}
}

public bool IsSunk() {
	return transform.localPosition.y<sunk;
}

}