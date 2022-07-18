using UnityEngine;
using System.Collections;

namespace Hyper {
public class HydrantBounce : MonoBehaviour {

	

void OnTriggerStay (Collider collision) {
	float force = Mathf.Max(0.0f,100.0f - collision.gameObject.transform.position.y);
	collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f,force,0.0f));
}

}
}