using UnityEngine;
using System.Collections;

namespace Fugu {
	
	/// <summary>
	/// Material modifier.
	/// </summary>
abstract public class MaterialModifier : MonoBehaviour {

	abstract protected Material material { get; }
		
	protected void SetMainTexture(Texture2D tex) {
		material.SetTexture("_MainTex",tex);
	}
	
	protected void SetMainTextureOffset(Vector2 offset) {
		material.SetTextureOffset("_MainTex",offset);
	}
}
}