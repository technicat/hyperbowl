using UnityEngine;
using System.Collections;

namespace Hyper {

public class ScoreBoardAnimation : MonoBehaviour {

	
		
		private Hashtable htmove;
		private Hashtable htrot;
		
		void Awake() {
			htmove = iTween.Hash("z",0,"time",1,"easetype",iTween.EaseType.easeOutQuad);
			htrot = iTween.Hash("x",0,"time",1,"easetype",iTween.EaseType.easeOutQuad);
		}
		
		void ResetPosition() {
			Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x,pos.y,1);
			Vector3 rot = transform.eulerAngles;
			transform.eulerAngles = new Vector3(90, rot.y, rot.z);
		}
		
		void Play() {
			ResetPosition();
			iTween.MoveTo(gameObject,htmove);
			iTween.RotateTo(gameObject,htrot);
		}
		

}

}