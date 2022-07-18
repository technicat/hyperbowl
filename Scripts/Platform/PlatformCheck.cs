using UnityEngine;
using System.Collections;

namespace Fugu {

public class PlatformCheck : MonoBehaviour {

		public string publisher="hyperbowl.rocks";

	// Use this for initialization
	void Start () {
#if UNITY_WEBGL
		if (Application.absoluteURL.StartsWith("http://www."+publisher+"/") ||
						 Application.absoluteURL.StartsWith("http://"+publisher+"/")) {
				gameObject.SetActive (false);
			}
#endif
	
	}
	

}

}
