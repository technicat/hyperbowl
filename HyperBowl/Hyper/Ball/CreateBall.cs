/* Copyright (c) 2013 Technicat, LLC */

using UnityEngine;
using System.Collections;

using Fugu;

// activate shared bowling ball or create from prefab if needed
namespace Hyper {
public class CreateBall : MonoBehaviour {
		
	public GameObject ballprefab = null; // ball prefab
		
	void Awake () {
		GameObject ballroot = GameObject.FindGameObjectWithTag ("BallRoot");
		if (ballroot != null) {
				ballroot.transform.parent = transform;
				GameObject ball = ObjectUtils.GetChild (ballroot);
				ballroot.transform.localPosition = Vector3.zero;
				ball.transform.localPosition = Vector3.zero;
				ball.SetActive (true);
		} else {
			Instantiate (ballprefab,transform.position,Quaternion.identity);
		}
	}
}
}