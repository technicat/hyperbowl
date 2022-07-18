using UnityEngine;
using System.Collections;

namespace Fugu {


public class Rotate : MonoBehaviour {

		
		public float x = 0;
		public float y=0;
		public float z=0;

		private Transform trans;
		
		void Start () {
			trans = transform;
		}
		
		void Update () {
			float dtime = Time.deltaTime;
			trans.Rotate(x*dtime,y*dtime,z*dtime);
		}

	
}

}
