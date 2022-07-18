using UnityEngine;
using System.Collections;

namespace Fugu {
public class RandomTexture : MaterialModifierObject {
	public Texture2D[] textures;

	void Start () {
			SetRandomTexture();
		}
		
	public void SetRandomTexture() {
		SetMainTexture(textures[Random.Range(0,textures.Length)]);
	}
	
}
}