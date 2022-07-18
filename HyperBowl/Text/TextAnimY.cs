using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class TextAnimY : MonoBehaviour {

	public float startTime = 0f;

	private float start = -1.5f;
	private float end = 1.5f;
	private float mid = 0.1f; // distance for little bounce in the middle

	private float origy;

	private Hashtable htstart;
	private Hashtable htmid;
	private Hashtable htend;

	void Awake ()
	{
		origy = transform.position.y;
		htstart = iTween.Hash("oncomplete","PlayMid","delay",startTime,"y",mid+origy,"speed",2,"easetype",iTween.EaseType.easeOutQuad);
		htmid = iTween.Hash("oncomplete","PlayEnd","y",origy-mid,"speed",0.25,"easetype",iTween.EaseType.easeInOutQuad);
		htend = iTween.Hash("y",end+origy,"speed",2,"easetype",iTween.EaseType.easeInQuad);
	}

	void ResetPosition() {
			Vector3 pos = new Vector3(transform.position.x,start+origy,transform.position.z);
			transform.position = pos;
	}

	void Play() {
		ResetPosition();
		iTween.MoveTo(gameObject,htstart);
	}

	void PlayMid() {
		iTween.MoveTo(gameObject,htmid);
	}

	void PlayEnd() {
		iTween.MoveTo(gameObject,htend);
	}



}
}