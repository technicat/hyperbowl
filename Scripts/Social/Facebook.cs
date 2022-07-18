using UnityEngine;
using System.Collections;

namespace Fugu {

public class Facebook : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if P31_FB
		FacebookCombo.init();
#endif
	}
	
}

}