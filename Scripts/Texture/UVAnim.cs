using UnityEngine;
using System.Collections;

namespace Fugu {
	
sealed public class UVAnim : MaterialModifierObject {
	public Vector2 speed;

	private Vector2 offset;
		
	// Use this for initialization
	void Start () {
		offset=new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		float dtime = Time.deltaTime;
		offset.x=(offset.x+speed.x*dtime)%1.0f;
		offset.y=(offset.y+speed.y*dtime)%1.0f;
		SetMainTextureOffset(offset);
	}
}
}