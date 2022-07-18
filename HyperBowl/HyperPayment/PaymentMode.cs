using UnityEngine;
using System.Collections;

namespace Hyper {
public class PaymentMode : MonoBehaviour {

	

// HyperBowl payment screen - multiplayer selection

public int playernum = 1;

		public GameObject[] coinson;
		public GameObject[] coinsoff;

		#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
void OnButtonDown
#else
void OnMouseDown
#endif
() {
	Game.numplayers = playernum;
	for (int i=0; i<coinsoff.Length; ++i) {
		coinsoff[i].SetActive(false);
	}
	for (int j=0; j<coinson.Length; ++j) {
		coinson[j].SetActive(true);
	}
	GetComponent<AudioSource>().Play();
}
	}}