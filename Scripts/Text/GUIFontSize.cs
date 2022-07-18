using UnityEngine;
using System.Collections;

namespace Fugu {
	
sealed public class GUIFontSize : MonoBehaviour {
		
	public float baseHeight = 480.0f;
		
	// Use this for initialization
	void Start () {
		GetComponent<GUIText>().fontSize = (int)(GetComponent<GUIText>().fontSize * Screen.height/baseHeight);
	}
	
}
}