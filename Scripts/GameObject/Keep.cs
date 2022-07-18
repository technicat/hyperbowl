/* Copyright (c) 2013 Technicat, LLC. All Rights Reserved. */

using UnityEngine;
using System.Collections;

namespace Fugu {
/// <summary>
/// Attach to the GameObject or root of the GameObject hierarchy
/// that you want to preserve across scene loads
/// </summary>
public class Keep : MonoBehaviour {

	/// <summary>
	/// Just calls DonDestroyLoad on the GameObject
	/// </summary>
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
}
}