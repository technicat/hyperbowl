using UnityEngine;
using System.Collections;

namespace Hyper {
public class Piston : MonoBehaviour {

	
/* piston movement */

public float dist=5.0f;

public float speed = 1.0f;

public float delay = 0.0f;

		private float delayscale=5.0f;
		private float starty;



void Start () {
	starty = transform.localPosition.y;
	/*	transform.position.y -=2;
	yield WaitForSeconds(delay);
	iTween.MoveTo(gameObject,{"y":transform.position.y+4,"speed":4,"looptype":iTween.LoopType.pingPong}); */
}

void Update () {
			Vector3 pos = new Vector3(transform.localPosition.x, 
				starty + Mathf.PingPong((delay*delayscale+Time.time*speed),dist),
				transform.localPosition.z);
	transform.localPosition=pos;
}
}}