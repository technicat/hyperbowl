using UnityEngine;
using System.Collections;

namespace Hyper {
public class TrophyPlayer : MonoBehaviour {

	public int hyperplayer = 0;

	public bool lowerbox = false;

	void Start () {
				string name;
				if (lowerbox && Trophy.IsTieGame()) {
					name = Trophy.names[hyperplayer+1];
				} else {
					name = Trophy.names[hyperplayer];
				}
			TextMesh text3d = GetComponent<TextMesh>();
				text3d.text = name;
			}
	
	}
}
