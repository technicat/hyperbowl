using UnityEngine;
using System.Collections;

//  detect touch using this GameObject's Camera
//  and send OnButtonDown message to every GameObject that was touched

// todo - move to Fugu

namespace Hyper {
public class ButtonDown : MonoBehaviour {
//#if !UNITY_EDITOR && 
		#if (UNITY_IPHONE || UNITY_ANDROID)
	private int layermask = 0;
		
	const float distance = 150.0f;

		Camera cam;

	void  Awake() {
			cam = GetComponent<Camera>();
			if (cam != null) {
			layermask=cam.cullingMask;
			} else {
				Debug.Log("missing Camera for ButtonDown script");
			}
	}
		
	void Update () {
			if (Time.timeScale !=0  && cam != null && !UAP_AccessibilityManager.IsEnabled()) {
			RaycastHit hit;
			for (int i = 0; i < Input.touchCount; ++i) {
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began) {
				// Construct a ray from the current touch coordinates
					Ray ray = cam.ScreenPointToRay (touch.position);
					if (Physics.Raycast (ray,out hit,distance,layermask)) {
						hit.transform.gameObject.SendMessage("OnButtonDown");
					}
				}
			}
		}
	}
#endif
}


}