using UnityEngine;
using System.Collections;

namespace Fugu {
public class RockingPlatform : MonoBehaviour {
		
	public float speed = 1.0f;
	public float rockness = 5.0f;
	public float delay = 0.0f;
		
	private Transform trans;
	private Rigidbody rb;
	private bool rock = false;
		
	void Awake() {
			trans = transform;
			rb = GetComponent<Rigidbody>();
		}

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(delay);
		rock = true;
	}
	
	void FixedUpdate() {
		if (rock) {
			Vector3 angles = trans.localEulerAngles;
			angles.z = Mathf.Sin(Time.time*speed)*rockness;
			rb.MoveRotation(Quaternion.Euler(angles.x,angles.y,angles.z));
			
		}
	}
}
}