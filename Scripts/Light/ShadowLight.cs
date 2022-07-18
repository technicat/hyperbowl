using UnityEngine;
using System.Collections;

//#pragma strict

//static var shadowsOn:boolean = true;
namespace Fugu {

	public class ShadowLight : MonoBehaviour {
	
	void Start()  {
	UpdateShadows();
}


void UpdateShadows () {
	#if UNITY_STANDALONE || UNITY_WSA || UNITY_TVOS
	gameObject.GetComponent<Light>().shadows = LightShadows.Soft;
	#endif
	#if UNITY_IOS
	if (Fugu.Platform.IsHDPlus()) {
	gameObject.GetComponent<Light>().shadows = LightShadows.Hard;
	} else {
	gameObject.GetComponent<Light>().shadows = LightShadows.None;
	}
	#endif
	#if UNITY_ANDROID
	gameObject.GetComponent<Light>().shadows = LightShadows.None;
	#endif
}
}

}



