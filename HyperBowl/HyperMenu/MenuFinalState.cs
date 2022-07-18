using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuFinalState : MonoBehaviour {

	public string state;

	void OnEnable () {
	Menu.finalstate = state;
	}
}
}