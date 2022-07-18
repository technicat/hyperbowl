/* Copyright (c) 2013 Technicat, LLC */

using UnityEngine;
using System.Collections;

namespace Fugu {
public class ObjectUtils {
		
	static public void ActivateChildren(GameObject obj) {
		if (obj != null) {
			for (var i=0; i<obj.transform.childCount; ++i) {
				obj.transform.GetChild(i).gameObject.SetActive(true);
			}
		}
	}
		
	static public void DeactivateChildren(GameObject obj) {
		if (obj != null) {
			for (var i=0; i<obj.transform.childCount; ++i) {
				obj.transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}

	static public GameObject GetChild(GameObject obj) {
		return GetChild(obj,0);
	}
		
	static public GameObject GetChild(GameObject obj,int i) {
		if (obj.transform.childCount>i) {
			return obj.transform.GetChild(i).gameObject;
		} else {
		//	Debug.Log ("No child found");
			return null;
			}
	}



}
}
