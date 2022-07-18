using UnityEngine;
using System.Collections;

namespace Fugu {
public class OnlyHDPlus : MonoBehaviour {

	// Use this for initialization
	void  Awake () {
			gameObject.SetActive(Fugu.Platform.IsHDPlus());
		}
	}
}
