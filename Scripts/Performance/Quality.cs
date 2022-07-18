using UnityEngine;

// global render quality settings
// see Render.cs for per-scene settings

namespace Fugu {
	
sealed public class Quality : MonoBehaviour {
		
	public int frameRate = 60;

	void Awake () {
		Application.targetFrameRate = frameRate;

    QualitySettings.masterTextureLimit = 0;
    QualitySettings.vSyncCount = 1;
    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
    QualitySettings.antiAliasing = 0;
/* #if UNITY_IPHONE || UNITY_ANDROID || UNITY_WEBGL
	QualitySettings.pixelLightCount = 0;
#else
	QualitySettings.pixelLightCount = 2;
#endif */
			// set shadow distance is per scene

}
	
}
	
} // end namespace
