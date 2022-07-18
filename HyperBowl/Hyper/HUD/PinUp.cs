using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class PinUp : MonoBehaviour {

		public string pintag;

		private PinStatus status;

		void OnEnable () {
			GameObject pin = GameObject.FindWithTag(pintag);
				if (pin != null) {
				status = pin.GetComponent<PinStatus>();
					GetComponent<Renderer>().enabled = true;
				} else {
					status = null;
				}
			}

		void Update () {
				if (status == null || status.IsKnockedOver()) {
					GetComponent<Renderer>().enabled = false;
				}
			}

	
	}
}

