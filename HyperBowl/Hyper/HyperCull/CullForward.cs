using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class CullForward : MonoBehaviour {

public GameObject water;

// cull object if camera passes this z position (in the negative z direction)
public float front = 0;

private Transform mytrans;

void Awake() {
	mytrans = transform;
}

// start culling
void Start() {
	if (water.activeSelf) {
		StartCoroutine(UpdateCull());
	}
}

IEnumerator UpdateCull () {
	while (true) {
		if (mytrans.position.z<=front && !water.activeSelf) {
			water.SetActive(true);
		} 
		if (mytrans.position.z>front && water.activeSelf) {
			water.SetActive(false);
		}
				yield return null;
	}
}
	}
}