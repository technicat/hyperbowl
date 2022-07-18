/* Copyright (c) 2013 Technicat, LLC. All Rights Reserved. */

using UnityEngine;
using System.Collections;

namespace Hyper {

	/// <summary>
	/// Animate slice of the HyperBowl scene open/close wipe
	/// </summary> 
public class WipeSlice : MonoBehaviour {

	private const float animTime = 0.5f;

	private Hashtable htopen;
	private Hashtable htclose;

	void Awake() {
		htopen = iTween.Hash("time",animTime,"z",-60,"easetype",iTween.EaseType.linear);
		htclose = iTween.Hash("time",animTime,"z",0,"easetype",iTween.EaseType.linear);
	}

	public void PlayOpen() {
		iTween.RotateTo(gameObject,htopen);
	}
		
	public void PlayClose() {
		iTween.RotateTo(gameObject,htclose);
	}


}
}