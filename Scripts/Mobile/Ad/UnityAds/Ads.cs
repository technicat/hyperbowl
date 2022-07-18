using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if FUGU_VIDEO_ADS
using UnityEngine.Advertisements;
#endif
// convenience functions for ads
// cross-middleware wrapper

namespace Fugu {
	
public class Ads : MonoBehaviour {

	
	public void Show() {
		 Ads.ShowAd();
	}

	static  public bool ShowAd() {
#if FUGU_VIDEO_ADS
			if (Advertisement.IsReady()) {
	Advertisement.Show();
				return true;
			} else {
				return false;
			}
#endif
#if !FUGU_VIDEO_ADS
			return false;
#endif
	}
}

}