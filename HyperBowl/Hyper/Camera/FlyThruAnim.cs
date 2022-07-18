using UnityEngine;
using System.Collections;

namespace Hyper {
	
	public class FlyThruAnim : MonoBehaviour {

		public float animTime = 1.0f;

		public Transform start;
		public Transform end;
		public Vector3 offset = new Vector3(0f,0.4f,2.5f);

		public	Transform[] path;

		private Vector3[] finalpath;

		private Vector3 startPos;
		private Vector3 endPos;

		private Hashtable pathhash;

		void  Awake () {
			startPos = start.position+offset;
			endPos = end.position+offset;
			ResetPosition();
			finalpath = new Vector3[path.Length+2];
			finalpath[0]=startPos;
			for (int i=0;i<path.Length; i++) {
				finalpath[i+1]=path[i].position;
			}
			finalpath[path.Length+1]=endPos;
			#if ITWEEN
			pathhash = iTween.Hash("movetopath",false,"position",endPos,"path",finalpath,"time",animTime,"easetype",iTween.EaseType.easeInOutQuad);
			#endif
		}

		// reset camera to place behind the ball
		void ResetPosition() {
			transform.position=endPos;
		}

		void StartPosition() {
			transform.position=startPos;
		}

		void PlayAnimation() {
			StartPosition();
			#if ITWEEN
			iTween.MoveTo(gameObject,pathhash);
			#else
			ResetPosition();
			#endif
		}

	}
}