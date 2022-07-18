using UnityEngine;
using System.Collections;

namespace Fugu {
	
	/// <summary>
	/// Modify a Material stored in this GameObject
	/// and potentially used by many GameObjects
	/// </summary>
abstract public class MaterialModifierShare : MaterialModifier {
		
	public Material sharedMaterial;
		
	override protected Material material {
			get { return sharedMaterial; }
		}
	
}
}