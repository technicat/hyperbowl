using UnityEngine;

namespace Fugu {
public class PlatformActive : MonoBehaviour {
		
// one for every Unity platform def
	public bool iOS = false;
	public bool Android = false;
	public bool WSA = false;
	public bool WebGL = false;
	public bool OSX = false;
	public bool Windows = false;
	public bool Linux = false;
	public bool AppleTV = false;

	void Awake () {
#if UNITY_TVOS
		gameObject.SetActive(AppleTV);
#endif
#if UNITY_IOS
		gameObject.SetActive(iOS);
#endif
#if UNITY_ANDROID
		gameObject.SetActive(Android);
#endif
#if UNITY_WEBGL
		gameObject.SetActive(WebGL);
#endif
#if UNITY_STANDALONE_OSX
		gameObject.SetActive(OSX);
#endif
#if UNITY_STANDALONE_WIN
		gameObject.SetActive(Windows);
#endif
#if UNITY_WSA
		gameObject.SetActive(WSA);
#endif
#if UNITY_STANDALONE_LINUX
		gameObject.SetActive(Linux);
#endif
        }

    }
}
