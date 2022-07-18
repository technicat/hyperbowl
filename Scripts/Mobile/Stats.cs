using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_ANALYTICS
using UnityEngine.Analytics;
#endif

namespace Fugu {
public class Stats : MonoBehaviour {

	
	public string appId = "";
/*	
#if UNITY_ANALYTICS
	// Use this for initialization
	void Start () {
			Debug.Log ("Starting analytics...");
		UnityAnalytics.StartSDK (appId);
		
	}
#endif
*/
	static public void Event(string name,  IDictionary<string, object> data) {
#if UNITY_ANALYTICS
			Analytics.CustomEvent(name, data);
#endif
	}

		static public void Score( string level, string player, int complete, int score) {
			Event("score", new Dictionary<string, object> {
				{ "level",level },
				{ "player",player},
				{ "complete",complete },
				{ "score",score }
			}
			);
		}
	
}
}