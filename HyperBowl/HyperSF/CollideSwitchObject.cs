using UnityEngine;
using System.Collections;

namespace Hyper {
public class CollideSwitchObject : MonoBehaviour {

	

public GameObject nextObject;
public float delay= 0.5f; // avoids flipping through a bunch of objects on one collision

private float startTime =0;

void Start() {
	startTime = Time.time;
}

void OnCollisionEnter(Collision collision) {
	if ((Time.time - startTime)>delay) {
		nextObject.SetActive(true);
		gameObject.SetActive(false);
	}
}

}
}