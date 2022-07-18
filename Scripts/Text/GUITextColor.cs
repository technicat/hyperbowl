using UnityEngine;
using System.Collections;

namespace Fugu {
public class GUITextColor : MonoBehaviour {
		
	public Color color = Color.black;

	// Use this for initialization
	void Start () {
		GetComponent<GUIText>().material.color = color;
	}
	
}
	
}
