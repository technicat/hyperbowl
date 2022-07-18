using UnityEngine;
using System.Collections;
namespace Hyper {
public class GutterTrigger : MonoBehaviour {

	
	void OnTriggerEnter (Collider collider) {
		Bowl.gutterTriggered = true;
	}
}
}