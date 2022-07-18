using UnityEngine;
using System.Collections;

namespace Fugu {
public class ChartboostApps : MonoBehaviour {

#if UNITY_IPHONE && CHARTBOOST && CHARTBOOST_APPS
	void Start () {
			ChartboostBinding.showMoreApps();
	}
#endif
	}

}
