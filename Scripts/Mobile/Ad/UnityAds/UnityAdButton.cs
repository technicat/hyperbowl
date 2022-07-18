using UnityEngine;
using System.Collections;
/*
#if FUGU_VIDEO_ADS
using UnityEngine.Advertisements;
#endif */

namespace Fugu {

	public class UnityAdButton : MonoBehaviour {

		// Use this for initialization
		public void Show () {
			Ads.ShowAd();
		/*	#if FUGU_VIDEO_ADS
			if (Advertisement.IsReady ()) 
				Advertisement.Show();
			#endif */

		}
	}


}
