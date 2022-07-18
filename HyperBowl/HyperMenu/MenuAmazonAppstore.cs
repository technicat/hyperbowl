using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuAmazonAppstore : MonoBehaviour {

	public string desturl;

		public string amzurl;

	void ButtonDown () {
			Menu.desturl = amzurl; // desturl;
	Menu.finalstate = "NextAppStore";
	}
}
}