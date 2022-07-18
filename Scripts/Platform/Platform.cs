/* Copyright (c) 2009 Technicat, LLC */

using UnityEngine;
using System.Collections;

#if P31_ETC
using Prime31;
#endif

namespace Fugu {

public class Platform {

#if UNITY_IOS
static public bool IsFirstGenIPhone() {
	return UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone ||
		UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch1Gen;
}

static public bool IsSecondGenIPhone() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone3G ||
		UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch2Gen;
}

static public bool IsThirdGenIPhone() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone3GS ||
		UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch3Gen;
}

static public bool IsFourthGenIPhone() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone4 ||
		UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch4Gen;
}

		static public bool IsFifthGenIPhone() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone5 ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch5Gen;
		}

		static public bool IsSixthGenIPhone() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone6 ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPodTouch6Gen;
		}

		static public bool IsIPhone6() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone6 ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone6Plus;
		}

		static public bool IsIPhone7() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone7 ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone7Plus;
		}

	static public bool IsIPhone8() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone8 ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhone8Plus;
		} 

static public bool IsFirstGenIPad() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad1Gen;
}

static public bool IsSecondGenIPad() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad2Gen;
}

static public bool IsThirdGenIPad() {
	return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad3Gen;
}

		static public bool IsFourthGenIPad() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad4Gen;
		}

		static public bool IsIPadAir1() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadAir1 ; //  5th gen iPad
		}

		static public bool IsIPadAir2() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadAir2 ;
		}

		static public bool IsIPadAir() {
			return	IsIPadAir1() || IsIPadAir2() ;
		}

	/*	static public bool IsSixthGenIPad() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPad6Gen;
		} */

		static public bool IsIPadPro() {
			return	UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadPro1Gen ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadPro2Gen ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadPro3Gen ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadPro10Inch1Gen ||
				UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPadPro11Inch;
			// need to add new generations as they arrive
		}
#endif
		
static public void OpenYouTube(string desturl) {
/*#if UNITY_IOS && P31_ETC
	EtceteraBinding.showWebPage(desturl, true);
#endif */
//#if UNITY_STANDALONE || UNITY_ANDROID || (UNITY_IPHONE && !P31_ETC) || UNITY_WSA
			#if !UNITY_WEBGL
	Application.OpenURL(desturl);
			#endif
//#endif
#if UNITY_WEBGL
	Application.ExternalEval("window.open('"+desturl+"');");
#endif
}

		static public void OpenWebPage(string desturl) {
			#if UNITY_IOS && P31_ETC
			EtceteraBinding.showWebPage(desturl, true);
			#endif
			#if UNITY_STANDALONE || UNITY_ANDROID || (UNITY_IPHONE && !P31_ETC) || UNITY_WSA
			Application.OpenURL(desturl);
			#endif
			#if UNITY_WEBGL
			Application.ExternalEval("window.open('"+desturl+"');");
			#endif
		}
		
static public bool IsHD() {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA || UNITY_TVOS
	return true;
#endif
#if UNITY_ANDROID
	return true;
#endif
#if UNITY_IOS
	return !IsThirdGenIPhone();
#endif
}

// can we handle more content?
static public bool IsHDPlus() {
#if UNITY_IOS
	return !IsThirdGenIPhone() && !IsFourthGenIPhone() && !IsFirstGenIPad();
#endif
#if UNITY_ANDROID
	return false; // for now
#endif
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA || UNITY_TVOS
	return true;
#endif
}

		static public bool HasShadows() {
		/*	#if UNITY_EDITOR
			return true;
			#endif */
			#if UNITY_IOS
			return IsIPadPro() || ( !IsFirstGenIPhone()  &&  !IsSecondGenIPhone() && !IsThirdGenIPhone() && !IsFourthGenIPhone() && !IsFifthGenIPhone());
			#endif
			#if UNITY_ANDROID && ITCHIO
			return true;
			#endif
			#if UNITY_ANDROID && !ITCHIO
			return false; // for now
			#endif
			#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_WSA || UNITY_TVOS
			return true;
			#endif
		}

// just so we don't have #if's everywhere
static public void LockCursor() {
	#if !UNITY_IOS && !UNITY_ANDROID
//	Screen.lockCursor = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
	#endif
}

static public void UnlockCursor() {
	#if !UNITY_IOS && !UNITY_ANDROID
	//Screen.lockCursor = false;
			Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
	#endif
}

static public void RequestReview() {
#if UNITY_IOS
	UnityEngine.iOS.Device.RequestStoreReview();
#endif
}

static public void StartActivityIndicator() {
#if UNITY_IPHONE
			Handheld.SetActivityIndicatorStyle(UnityEngine.iOS.ActivityIndicatorStyle.WhiteLarge);
#endif
#if UNITY_ANDROID
			Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.InversedLarge);
#endif
#if UNITY_IPHONE || UNITY_ANDROID
			Handheld.StartActivityIndicator();
#endif
}

static public void StopActivityIndicator() {
#if UNITY_ANDROID || UNITY_IPHONE
			Handheld.StopActivityIndicator();
#endif
}

	}
}
