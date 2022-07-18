using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class ShipRock : MonoBehaviour {
		
	private float speed=0.5f;
	private float rockness=5f;

	private float rocktime = 0.0f;

	private Transform trans;

		void Awake() {
		trans = transform;
	}

	void Update () {
		float z = Mathf.Sin(rocktime*speed)*rockness;
			Vector3 angles = new Vector3( trans.localEulerAngles.x,trans.localEulerAngles.y, z);
			trans.localEulerAngles = angles;
		rocktime+=Time.deltaTime;
	}

}
}