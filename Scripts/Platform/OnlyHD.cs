using UnityEngine;
using System.Collections;

namespace Fugu {
	public class OnlyHD : MonoBehaviour {

		// Use this for initialization
		void  Awake () {
			gameObject.SetActive(Fugu.Platform.IsHD());
		}
	}
}

