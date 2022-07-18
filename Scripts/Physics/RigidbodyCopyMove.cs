using UnityEngine;
using System.Collections;

namespace Fugu {
public class RigidbodyCopyMove : MonoBehaviour {
		
	public Transform target;
	public bool copyRotation;
	public bool copyMovement;
		
	private Rigidbody rb;
		
	void Awake() {
			rb = GetComponent<Rigidbody>();
		}
	
	void FixedUpdate() {
			rb.MoveRotation(target.rotation);
			rb.MovePosition(target.position);	
		}
	}
}
