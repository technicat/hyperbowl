using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class MothFly : MonoBehaviour {

	

	private int vert = 1000;
//	private int dist = 100;

	private Hashtable pathbegin;
	private Hashtable pathend;

	void Awake() {
		//Array path= Array();
		float orig = transform.position.y;
		pathbegin=iTween.Hash("y",orig,"speed",200,"oncomplete","PlayEnd","easetype",iTween.EaseType.easeOutQuad);
		pathend=iTween.Hash("z",100,"speed",100,"easetype",iTween.EaseType.easeInQuad);
	}

	void Start() {
			Vector3 pos = new Vector3(transform.position.x,
				transform.position.y+vert,
				transform.position.z);
			transform.position = pos;
		iTween.MoveTo(gameObject,pathbegin);
	}

	void PlayEnd() {
		iTween.MoveTo(gameObject,pathend);
	}


}
}