using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class TimerPause : MonoBehaviour {

	

//static bool paused = false;

// should be im a separate script, HyperTimeout.js

void OnEnable () {
	starttime = Time.time;
}

static float starttime = 0;

static public bool IsTimedOut() {
	return Time.time-starttime>25;
}

}
}