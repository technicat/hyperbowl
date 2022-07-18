using UnityEngine;
using System.Collections;

namespace Hyper {
public class PlaySound : MonoBehaviour {

void Play () {
	GetComponent<AudioSource>().Play();
}

}
}