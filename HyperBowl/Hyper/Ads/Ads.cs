using UnityEngine;
using System.Collections;

// move buttons up to make room for banner ads

namespace Hyper {
public class Ads : MonoBehaviour {

//	public float offset = 8f;

	//#if FUGU_ADS
	void Start () {
			Camera camera = Camera.main; // GetComponent<Camera>();
		float iPhone8Aspect = 750.0f/1334.0f;
		float aspect = (float)camera.pixelWidth/(float)camera.pixelHeight;
			if (aspect <  iPhone8Aspect) { // -1.0f/16.0f)  {
			Vector3 pos = new Vector3(transform.localPosition.x,transform.localPosition.y-100,transform.localPosition.z);
				transform.localPosition = pos;
			}
		}
//#endif

}
}