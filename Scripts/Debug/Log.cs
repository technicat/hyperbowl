using UnityEngine;
using System.Collections;

namespace Fugu {
	
	/// <summary>
	/// Log.
	/// </summary>
	public class Log : MonoBehaviour {

		public static void Deprecate (MonoBehaviour script) {
#if FUGU_DEBUG || UNITY_EDITOR
			Warn("Deprecated script attached to "+script.gameObject.name);
#endif
		}
		
		public static void Warn (string msg) {
#if FUGU_DEBUG || UNITY_EDITOR
			Debug.LogWarning(msg);
#endif
		}
		
		public static void Info (string msg) {
#if FUGU_DEBUG || UNITY_EDITOR
			Debug.Log(msg);
#endif
		}
	}
	
}
