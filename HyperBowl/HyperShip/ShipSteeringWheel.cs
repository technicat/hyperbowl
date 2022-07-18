using UnityEngine;
using System.Collections;

namespace Hyper {
public class ShipSteeringWheel : MonoBehaviour {

	
public GameObject ship;



void Update () {
			Vector3 rot = new Vector3(ship.transform.eulerAngles.x,
				ship.transform.eulerAngles.y,
				ship.transform.eulerAngles.z*-100);
				
			transform.eulerAngles = rot;
}

	}
}