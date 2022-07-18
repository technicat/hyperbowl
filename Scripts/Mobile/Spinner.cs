using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Fugu {
public class Spinner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(this.gameObject);
		StartCoroutine(StartActivityIndicator());
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		public void OnSceneLoaded(Scene scene, LoadSceneMode m) {
			#if UNITY_IPHONE || UNITY_ANDROID
			Handheld.StopActivityIndicator();
			#endif
			GameObject.Destroy(gameObject);
		}
		
	IEnumerator StartActivityIndicator () {
		#if UNITY_IPHONE
		Handheld.SetActivityIndicatorStyle(UnityEngine.iOS.ActivityIndicatorStyle.Gray);
		#endif
		#if UNITY_ANDROID
		Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.InversedLarge);
		#endif
#if UNITY_IPHONE || UNITY_ANDROID
		Handheld.StartActivityIndicator();
#endif
		yield return null;
}

/*	void OnLevelWasLoaded() {
#if UNITY_IPHONE || UNITY_ANDROID
		Handheld.StopActivityIndicator();
#endif
		GameObject.Destroy(gameObject);
} */
	
	
}
	
}