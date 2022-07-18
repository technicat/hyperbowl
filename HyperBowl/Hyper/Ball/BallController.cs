using UnityEngine;
using System.Collections;

namespace Fugu {
public class BallController : MonoBehaviour {
		
	private Behaviour controller = null;
		
	void Awake() {
		controller = GetComponent<BowlForce>();
	}

	void StartRolling() {
		controller.enabled = true;
	}

	void StopRolling() {
		controller.enabled = false;
	}
}
}