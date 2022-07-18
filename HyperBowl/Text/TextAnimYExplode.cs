using UnityEngine;
using System.Collections;

namespace Hyper {
public class TextAnimYExplode : MonoBehaviour {

public float startTime = 0f;

private float start = -1.5f; // -1.2f;
//private float end = 1.2f;
private float mid = 0.1f; // distance for little bounce in the middle

private float endz = 1.1f; // for last z anim

private float origy;
private float origz;

private Hashtable htstart;
private Hashtable htmid;
private Hashtable htend;
private Hashtable rot;

void Awake ()
{
	origy = transform.position.y;
	origz = transform.position.z;
	htstart = iTween.Hash("oncomplete","PlayMid","delay",startTime,"y",mid+origy,"speed",2,"easetype",iTween.EaseType.easeOutQuad);
	htmid = iTween.Hash("oncomplete","PlayEnd","y",origy-mid,"speed",0.25,"easetype",iTween.EaseType.easeInOutQuad);
	htend = iTween.Hash("z",endz,"time",1,"easetype",iTween.EaseType.easeInQuad);
	rot = iTween.Hash("y",180,"time",1,"easetype",iTween.EaseType.easeInQuad);
}

void ResetPosition() {
			Vector3 pos = new Vector3(	transform.position.x,start+origy,origz);
			transform.position  = pos;
	transform.eulerAngles = Vector3.zero;
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
	iTween.RotateTo(gameObject,rot);
}
}
}