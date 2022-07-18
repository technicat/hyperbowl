using UnityEngine;
using System.Collections;

namespace Fugu {
public class PlatformStore : MonoBehaviour {
		
	public bool Apple = false;
	public bool GooglePlay = false;
	public bool Amazon = false;
	public bool GameJolt = false;
	public bool ItchIO = false;
	public bool WindowsStore = false;
		public bool Steam = false;
	// Use this for initialization
	void Start () {
#if GAMEJOLT
	gameObject.SetActive(GameJolt);
#endif
#if ITCHIO
	gameObject.SetActive(ItchIO);
#endif
#if UNITY_IOS
		gameObject.SetActive(Apple);
#endif
#if GOOGLE
		gameObject.SetActive(GooglePlay);
#endif
#if AMAZON
		gameObject.SetActive(Amazon);
#endif
#if UNITY_WSA
			gameObject.SetActive(WindowsStore);
#endif
#if STEAM
			gameObject.SetActive(Steam);
#endif
	}

}
}