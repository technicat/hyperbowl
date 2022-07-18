using UnityEngine;
using System.Collections;

namespace Hyper {

public class TextAnimX : MonoBehaviour {

public float startTime = 0f;

private float start = 1f;
private float end = -1f;
private float mid = -0.1f; // distance for little bounce in the middle

private float orig;

private Hashtable htstart;
private Hashtable htmid;
private Hashtable htend;

void Awake ()
{
	orig = transform.position.x;
	htstart = iTween.Hash("oncomplete","PlayMid","delay",startTime,"x",mid+orig,"speed",2,"easetype",iTween.EaseType.easeOutQuad);
	htmid = iTween.Hash("oncomplete","PlayEnd","x",orig-mid,"speed",0.25,"easetype",iTween.EaseType.easeInOutQuad);
	htend = iTween.Hash("x",end+orig,"speed",2,"easetype",iTween.EaseType.easeInQuad);
}

void ResetPosition() {
			Vector3 pos = new Vector3(start+orig,transform.position.y,transform.position.z);
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