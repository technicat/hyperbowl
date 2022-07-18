using UnityEngine;
using System.Collections;

namespace Hyper {
public class Timer : MonoBehaviour {
		

// timer display

		public GameObject[] numbers;

private int seconds=0;

void OnEnable () {
	for (int i=0; i<25; i++) {
		numbers[i].SetActive(false);
	}
	seconds=26;
	InvokeRepeating("NextDigits",0f,1f);
	//	for (i=0; i<25; i++) {
	//		Invoke("NextDigits",i);
	//	}
}

		void OnDisable() {
			CancelInvoke();
		}

void NextDigits() {
	if (seconds<numbers.Length && seconds >=0) {
		numbers[seconds].SetActive(false);
	}
	--seconds;
	if (seconds<numbers.Length && seconds >= 0) {
		numbers[seconds].SetActive(true);
	}
	if (seconds < 6 && seconds >= 0) {
		GetComponent<AudioSource>().Play(); // beep
	}
}	
	}
}