using UnityEngine;
using System.Collections;

namespace Fugu {
sealed public class TextureAnimShare : MaterialModifierShare {
		
	/// <summary>
	/// The textures.
	/// </summary>
	public Texture2D[] textures;
		
	/// <summary>
	/// The interval.
	/// </summary>
	public float interval=0;
	
	/// <summary>
	/// The index.
	/// </summary>
	private int index;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		InvokeRepeating("NextTexture",interval,interval);
	}
	
	/// <summary>
	/// Nexts the texture.
	/// </summary>
	void NextTexture() {
		SetMainTexture(textures[index++]);
		if (index>=textures.Length) {
			index=0;
		}
	}
	
}
}