using UnityEngine;
using System.Collections;

namespace Fugu {
	/// <summary>
	/// Modify the Material on a GameObject
	/// </summary>
	abstract public class MaterialModifierObject : MaterialModifier {
		
		/// <summary>
		/// Specifies whether this Material is shared with other GameObjects
		/// </summary>
		public bool shared = true;
		
		/// <summary>
		/// The index of the material.
		/// </summary>
		public int materialIndex = 0;
		
		/// <summary>
		/// Gets the material.
		/// </summary>
		/// <value>
		/// The material.
		/// </value>
		override protected Material material {
			get {
				if (shared) {
					return GetComponent<Renderer>().sharedMaterials[materialIndex];
				} else {
					return GetComponent<Renderer>().materials[materialIndex];
				}
			}
		}
	}
}