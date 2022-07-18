using UnityEngine;
using System.Collections;

#if FUGU_VIDEO_ADS
using UnityEngine.Advertisements;
#endif

// should be called UnityAdWait

namespace Fugu {
public class UnityAdLoop : MonoBehaviour {

		void Start() {
			#if FUGU_VIDEO_ADS
			StartCoroutine("ShowAd");
			#endif
		}


	// Use this for initialization
	IEnumerator ShowAd () {
			#if FUGU_VIDEO_ADS
			while (!Advertisement.IsReady())  {
				yield return null;
			}
			Ads.ShowAd();
			//Advertisement.Show();
			#else
			yield return null;
			#endif
		}

	}
}



