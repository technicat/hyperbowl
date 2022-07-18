using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MenuYouTube : MonoBehaviour {

	

	public string desturl;


	void ButtonDown () {
	Menu.desturl = desturl;
	Menu.finalstate = "NextYouTube";
	}

}
}
