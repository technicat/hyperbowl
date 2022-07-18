using UnityEngine;
using System.Collections;

namespace Fugu {

	/// <summary>
	/// Allows reset to initial position
	/// Sleeps on reset
	/// </summary>
public class Reset : MonoBehaviour {

		public bool sleep = true;

		private Vector3 startPos;
		private Quaternion startRot;

		private Rigidbody rb;
		
		public void Awake() {
			rb = GetComponent<Rigidbody>();
			SetPosition();
			ResetPosition();
		}
		
		public void SetPosition() {
			startPos = transform.localPosition;
			startRot = transform.localRotation;
		}
		
		public void ResetPosition() {
			transform.localPosition = startPos;
			transform.localRotation = startRot;
			if (rb != null) {
				if (sleep) {
					rb.Sleep();
				} else {
					rb.velocity = Vector3.zero;
					rb.angularVelocity = Vector3.zero;
				}
			}
}

}
}