using UnityEngine;
using System.Collections;

namespace Fugu {

	public class Chartboost : MonoBehaviour {

		public string id = "";
		public string sig="";

		public string AndroidID = "";
		public string AndroidSig = "";

		void Start () {
#if CHARTBOOST
			global::Chartboost.init (AndroidID, AndroidSig, id,sig, false);
#endif
#if CHARTBOOST_APPS
			global::Chartboost.cacheMoreApps ();
#endif
#if CHARTBOOST_ADS
			global::hartboost.cacheInterstitial(null);
#endif
	}
}

}
