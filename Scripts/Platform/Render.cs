using UnityEngine;
using System.Collections;

namespace Fugu {

	// per-scene render/quality settings

public class Render : MonoBehaviour {

		public bool mobileShadow = false;

		public float shadowDistance = 20; // hard shadows
		public float deluxeShadowDistance = 200; // soft shadows
		public int pixelLights = 1;
		public int shadowCascades = 0;
		public int shadowNearPlaneOffset = 2;
		//var physicsTime:float = 0.2f;
		
		public void Awake() {
			// fog is in Window->Lighting
			//RenderSettings.fog = true;
			#if UNITY_STANDALONE || UNITY_WSA
			QualitySettings.pixelLightCount = pixelLights;
			QualitySettings.shadowDistance = deluxeShadowDistance;
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = ShadowResolution.High;
			QualitySettings.shadowProjection = ShadowProjection.CloseFit;
			QualitySettings.shadowCascades = shadowCascades;
			#endif
			#if UNITY_WEBGL || UNITY_TVOS
			QualitySettings.shadows = ShadowQuality.Disable;
			QualitySettings.shadowDistance = shadowDistance;
			QualitySettings.pixelLightCount = 0;
			#endif
			#if UNITY_IOS || UNITY_ANDROID
			if (mobileShadow && Fugu.Platform.HasShadows()) {
				QualitySettings.shadows  = ShadowQuality.HardOnly; // All;
				QualitySettings.shadowResolution = ShadowResolution.High;
				QualitySettings.shadowDistance = shadowDistance;
				QualitySettings.shadowNearPlaneOffset = shadowNearPlaneOffset;
				QualitySettings.shadowCascades = 0;
				QualitySettings.pixelLightCount = 0; // pixelLights;
			} else {
				QualitySettings.shadows  = ShadowQuality.Disable;
				QualitySettings.pixelLightCount = 0;
			}
			//QualitySettings.shadowDistance = shadowDistance;
			QualitySettings.pixelLightCount = 0;
			#endif
			// override per-scene fog on Android
			#if UNITY_ANDROID
			RenderSettings.fog = false;
			QualitySettings.pixelLightCount = 0;
			#endif
			//Time.fixedDeltaTime = physicsTime;
		}

}

}
