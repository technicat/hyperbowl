using UnityEngine;
using System.Collections;

namespace Fugu {
	
public class MovingPlatformX : MonoBehaviour {
		
	/// <summary>
	/// Start this instance.
	/// </summary>
	public float dist = 5.0f;
	public float delay = 3.0f;
	public float speed = 1.0f;
	
	private float startx;
		
	//private Rigidbody rb;
	private Transform trans;

	// Use this for initialization
	void Awake () {
		trans = transform;
//		rb = rigidbody;
		startx = trans.position.x-dist/2.0f;
	}
	
	IEnumerator Start() {
		yield return new WaitForSeconds(delay);
		StartCoroutine(Move());
	}
		
	IEnumerator Move() {
		while (true) {
			Vector3 pos = trans.position;
			pos.x = startx + Mathf.PingPong((Time.time*speed),dist);
			//rb.MovePosition(pos);
			transform.position = pos;
			yield return null;
		}
	}
	
}
}