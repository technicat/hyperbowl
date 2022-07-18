using UnityEngine;
using System.Collections;

namespace Fugu {
public class SnapToGround : MonoBehaviour {

		public int groundlayer = 26;
		public int hilllayer = 28;


		void Start()  {
			float dist = transform.localPosition.y;
			RaycastHit hit;
			if (Physics.Raycast(transform.position,-Vector3.up,out hit,10000,1<<groundlayer | 1<<hilllayer)) {
				Vector3 pos = new Vector3(transform.position.x,hit.point.y+dist,transform.position.z);
				transform.position = pos;
			}
		}
	}
}
