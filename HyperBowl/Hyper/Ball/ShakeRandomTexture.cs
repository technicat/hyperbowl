using UnityEngine;
using System.Collections;

namespace Hyper {
public class ShakeRandomTexture : Fugu.RandomTexture {
	
	void Update () {
			if (Input.acceleration.sqrMagnitude>5.0) {
				SetRandomTexture();
			}
	
	}
}
}