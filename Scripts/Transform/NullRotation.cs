using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// don't inherit parent rotation

namespace Fugu {

public class NullRotation : MonoBehaviour {

	
	void FixedUpdate ()
{
	transform.rotation = Quaternion.identity;
}
}

}