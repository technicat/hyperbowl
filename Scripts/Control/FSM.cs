/* Copyright (c) 2013 Technicat, LLC. All Rights Reserved. */

using UnityEngine;
using System.Collections;

namespace Fugu {
	/// <summary>
	/// FS.
	/// </summary>
public abstract class FSM : MonoBehaviour {
	

		/// <summary>
		/// The state.
		/// </summary>
		protected string state = null; // maybe make this an accessor
		
		/// <summary>
		/// Runs the FS.
		/// </summary>
		/// <returns>
		/// The FS.
		/// </returns>
		IEnumerator RunFSM () {
			while (state != null) {
				yield return null;
//					Log.Info(Application.loadedLevelName+" entering state "+state);
				yield return StartCoroutine(state);
			}
		}
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public virtual void Start() {
			StartCoroutine (RunFSM ());
		}
		
}
}
