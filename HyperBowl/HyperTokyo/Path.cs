using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class Path : MonoBehaviour {

	
// light rail on the bridge in the Tokyo lane

public Transform[] path;

public float delay = 0f;

public float time=10;

public bool orient=false;

private Hashtable pathhash;

void Awake() {
	pathhash = iTween.Hash("looktime",0.1,"orienttopath",orient,"time",time,"delay",delay,"path",path,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.loop);
}
void Start () {
	transform.position = path[0].transform.position;
	iTween.MoveTo(gameObject,pathhash);
}

}
}