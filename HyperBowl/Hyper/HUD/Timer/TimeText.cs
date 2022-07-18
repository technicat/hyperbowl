using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class TimeText : MonoBehaviour {

	

private int seconds=0;

private TextMesh text3d;


void Start () {
//	int score = PlayerPrefs.GetInt("Player1Score",0);
			text3d= GetComponent<TextMesh>();

}

void OnEnable () {
	seconds=25;
	for (int i=0; i<25; i++) {
		Invoke("NextDigits",i);
	}
}

void NextDigits() {
	text3d.text = seconds.ToString();
	--seconds;
	if (seconds < 6) {
		GetComponent<AudioSource>().Play(); // beep
	}
}	

void OnDisable() {
	CancelInvoke();
}
}
}