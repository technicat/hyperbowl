using UnityEngine;
using System.Collections;

namespace Hyper {

public class Door : MonoBehaviour {

	public bool web = false;

	private Hashtable path;

	void Awake() {
		path = iTween.Hash("y",-10,"speed",1,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.none);
	}

	void Start() {
		if (Game.pro) {
			iTween.MoveTo(gameObject,path);
	}
	}
}
}