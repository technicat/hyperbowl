using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuLink : MonoBehaviour {

	
	public string desturl;

	void ButtonDown () {
		Menu.desturl = desturl;
		Menu.finalstate = "NextPage";
	}



}
}