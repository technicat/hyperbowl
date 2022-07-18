using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class PinStatus : MonoBehaviour {

	private float fallenHeight = 0.05f;

private bool knockedOver = false;

private float startY;

private Transform trans;

void Awake() {
	trans = transform;
	startY = trans.localPosition.y;
}

void ResetPosition() {
	knockedOver = false;
}

public bool KnockedOver () {
	return  startY-trans.localPosition.y>fallenHeight;
}

public bool IsKnockedOver() {
	return knockedOver;
}

void Update() {
	if (!knockedOver && KnockedOver()) {
		knockedOver = true;
	}
}
	}
}