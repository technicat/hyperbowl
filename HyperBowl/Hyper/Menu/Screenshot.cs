using UnityEngine;
using System.Collections;

#if P31_ETC
using Prime31;
#endif

namespace Fugu {
public class Screenshot : MonoBehaviour {


	void Awake () {
//  FingerGestures.OnRotationEnd += OnRotationEnd;
}

void OnRotationEnd(Vector2 pos1,Vector2 pos2, float angle) {
#if UNITY_IPHONE && P31_ETC
	//		StartCoroutine(EtceteraBinding.showMailComposerWithScreenshot ("","HyperBowl screenshot","I'm playing HyperBowl!",false));
#endif
}
}
}
