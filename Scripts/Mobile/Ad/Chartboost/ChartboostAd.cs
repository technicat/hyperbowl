using UnityEngine;
using System.Collections;

namespace Fugu {

public class ChartboostAd : MonoBehaviour {

#if UNITY_IPHONE && CHARTBOOST && CHARTBOOST_ADS
	void Start () {
	ChartboostBinding.showInterstitial(null);
}
		#endif
}

}
