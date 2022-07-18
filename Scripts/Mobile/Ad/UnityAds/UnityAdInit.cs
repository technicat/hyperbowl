using UnityEngine;
using System.Collections;

// Copyright (c) 2017 Technicat LLC

// this is used to initializeUnity Ads from the Asset Store
// not necessary for Unity Services

// maybe should have a different def
#if FUGU_VIDEO_ADS
using UnityEngine.Advertisements;
#endif

namespace Fugu {

public class UnityAdInit : MonoBehaviour {

		public string AppStoreID = "26128";
		public string GooglePlayID = "1144610";

		void Start() {
			//if (Advertisement.isSupported) {
			//	Advertisement.allowPrecache = true;
#if FUGU_VIDEO_ADS
			#if UNITY_IOS
			Advertisement.Initialize (AppStoreID);  //appstore
			#endif
			#if UNITY_ANDROID
			Advertisement.Initialize (GooglePlayID); // android
			#endif
#endif
			//} else {
			//	Debug.Log("Platform not supported");
			//}
	
	}
}
}
		


