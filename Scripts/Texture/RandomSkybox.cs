using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fugu {

public class RandomSkybox : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake () {
	    Object[] skies = Resources.LoadAll("Skybox",typeof(Material));
	if (skies != null) {
		var sky = skies[Random.Range(0,skies.Length-1)];
		RenderSettings.skybox = sky as Material;
	    }
    }   
}

}
