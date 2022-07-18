using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuAppstore : MonoBehaviour {

	public string desturl;

	void ButtonDown () {
	Menu.desturl = desturl;
	Menu.finalstate = "NextAppStore";
	}
}
}