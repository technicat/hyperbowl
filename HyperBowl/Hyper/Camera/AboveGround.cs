using UnityEngine;
using System.Collections;

namespace Hyper {
public class AboveGround : MonoBehaviour {

	
			// order after HyperFollow or other camera control

			public float dist = 0.2f;

		private Transform trans;

			void Awake() {
				trans = transform;
			}

			void Update () {
			RaycastHit hit;
			Vector3 orig = new Vector3(trans.position.x,trans.position.y+10,trans.position.z);
				if (Physics.Raycast(orig,-Vector3.up,out hit,100,1<<28)) {
				float y = Mathf.Max(trans.position.y, hit.point.y+dist);
				trans.position = new Vector3(trans.position.x,y,trans.position.z); 
				}
			}
	}
}
