using UnityEngine;
using System.Collections;

#if P31_ETC
using Prime31;
#endif

#if KAKERA
using Kakera;
#endif

namespace Fugu {

public class Photo : MonoBehaviour {

		public PhotoApply photoApply;

#if KAKERA
		private Unimgpicker picker;
#endif

		void Awake() {
#if KAKERA
			picker = GetComponent<Unimgpicker>();
			picker.Completed += (string path) =>
			{
				StartCoroutine(LoadImage(path));
			};
#endif
		}
	
	public void TakePhoto() {
#if P31_ETC && UNITY_IOS
			EtceteraBinding.promptForPhoto (1.0f);
#endif
#if P31_ETC && UNITY_ANDROID
			EtceteraAndroid.promptForPictureFromAlbum ("ball");
#endif
		
#if KAKERA
		UAP_AccessibilityManager.BlockInput(true);
		/*	if (imagePicker == null) {
				imagePicker = new Unimgpicker();
				imagePicker.Completed += (string path) =>
				{
					StartCoroutine(LoadImage(path));
				};
			} */
			picker.Show("Select Image", "unimgpicker.jpg", 1024);
#endif
#if NATIVEGALLERY
		NativeGallery.GetImageFromGallery( (string path) =>
			{
				StartCoroutine(LoadImage(path));
			}, 
			"Choose a custom ball texture", "image/*", -1 );
#endif
		}


	private IEnumerator LoadImage(string path)
	{
		var url = "file://" + path;
	//		Debug.Log("loading texture from photo at "+url);
		var www = new WWW(url);
		yield return www;

		var texture = www.texture;
		if (texture == null)
		{
			Debug.LogError("Failed to load texture url:" + url);
			} else {
				photoApply.textureLoaded(texture);
			}

		
		}
	}
}
