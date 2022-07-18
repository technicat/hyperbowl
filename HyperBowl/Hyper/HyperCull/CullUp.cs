using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class CullUp : MonoBehaviour {
		
		public GameObject water;

		public float front = 0;

		public bool waterVisible = false;

		private Transform  mytrans;

		void Start() {
			mytrans = transform;
			water.SetActive(waterVisible);
		}

		void Update () {
			if (!waterVisible) {
				if (mytrans.position.y<front) {
					waterVisible = true;
					water.SetActive(true);
				}
			} else {
				if (mytrans.position.y>front) {
					waterVisible = false;
					water.SetActive(false);
				}
			}

		}

	}
}
