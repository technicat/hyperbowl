using UnityEngine;
using System.Collections;

namespace Hyper {
public class ShipRockCollider : MonoBehaviour {

		public GameObject ship;

	private Rigidbody rb;
//	private Transform trans;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	//	trans = transform;
	}

	void FixedUpdate () {
		rb.MoveRotation(ship.transform.rotation);
	}


	}
}