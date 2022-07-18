using UnityEngine;
using System.Collections;

namespace Hyper {

public class ScoreLogoAnimation : MonoBehaviour {

		private Hashtable htmove;
		private Hashtable htrot;
		
		void Awake ()
		{
			htmove = iTween.Hash("y", transform.position.y,"time",1,"easetype",iTween.EaseType.easeOutQuad);
			htrot = iTween.Hash("y",0,"time",1,"easetype",iTween.EaseType.easeOutQuad);
		}
		
		void ResetPosition() {
			Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x, 1,pos.z);
			Vector3 rot = transform.eulerAngles;
			transform.eulerAngles = new Vector3(rot.x, 180, rot.z);
		}
		
		void Play() {
			ResetPosition();
			iTween.MoveTo(gameObject,htmove);
			iTween.RotateTo(gameObject,htrot);
		}
		

}

}
