using UnityEngine;
using System.Collections;

namespace Hyper {
public class FollowBall : Fugu.FollowBall {
	

/*	// the height we want the camera to be above the target
	public float height = 0.4f;
	// How much we 
	public float heightDamping = 2.0f;
	
	private Transform target;
	// The distance in the x-z plane to the target
	private float distance = -2.5f;
	private Transform trans; */
		
	// Use this for initialization
	protected override void Start () {
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		target = ball.transform;
		base.Start();
	}
	
	// Update is called once per frame
/*	void Update () {
		// Damp the height
		float currentHeight = Mathf.Lerp (trans.position.y, target.position.y+height, heightDamping * Time.deltaTime);
		// distance meters behind the target
		Vector3 position = target.position - Vector3.forward * distance;
		// Set the height of the camera
		trans.position = new Vector3(position.x,currentHeight,position.z);
	
	} */
}
}