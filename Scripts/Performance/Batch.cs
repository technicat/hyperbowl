using UnityEngine;
using System.Collections;

namespace Fugu {
public class Batch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StaticBatchingUtility.Combine (gameObject);
	}
	
}
}
