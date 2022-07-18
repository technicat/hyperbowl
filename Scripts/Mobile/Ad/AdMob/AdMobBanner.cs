// show AdMob banner ad
// using Prime31?

using UnityEngine;
using System.Collections;

namespace Fugu {

public class AdMobBanner : MonoBehaviour {
		
	public bool showOnTop = true;
	public string AdMobID = "";


#if UNITY_ANDROID && FUGU_ADS
		void Start() {
				AdMobAndroid.createBanner(AdMobID, AdMobAndroidAd.smartBanner, showOnTop ?
					AdMobAdPlacement.TopCenter : 
					AdMobAdPlacement.BottomCenter);
		}
#endif
	
}

} // end namespace
