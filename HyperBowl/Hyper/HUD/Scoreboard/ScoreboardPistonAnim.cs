using UnityEngine;
using System.Collections;

namespace Hyper {
public class ScoreboardPistonAnim : MonoBehaviour {

	
		private Hashtable ht;

			void Awake ()
			{
				ht=iTween.Hash("isLocal",true,"delay",1,"x", transform.localPosition.x,"speed",0.5,"easetype",iTween.EaseType.easeInOutQuad);
			}

			void ResetPosition() {
			Vector3 pos = new Vector3(0.4f,transform.localPosition.y,transform.localPosition.z);
			transform.localPosition = pos;
			}

			void Play() {
				ResetPosition();
				iTween.MoveTo(gameObject,ht);
			}


	
	}
}
