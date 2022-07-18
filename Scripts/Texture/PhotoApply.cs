using UnityEngine;
using System.Collections;

#if P31_ETC
using Prime31;
#endif

// patterned after EtceteraEventListener
// requires EtceteraManager
namespace Fugu {
	
	/// <summary>
	/// Photo apply.
	/// </summary>
sealed public class PhotoApply : MaterialModifierObject
{
		public float maxSize = 256.0f;
 
#if UNITY_IPHONE && P31_ETC
	void Start()
	{
		EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
	}
	
	void imagePickerChoseImage( string imagePath )
	{
		EtceteraBinding.resizeImageAtPath( imagePath, maxSize, maxSize );
		// Add 'file://' to the imagePath so that it is accessible via the WWW class
		StartCoroutine( EtceteraManager.textureFromFileAtPath( "file://" + imagePath, textureLoaded, textureLoadFailed ) );
	}
	
	public void textureLoadFailed( string error )
	{
	//	EtceteraBinding.showAlertWithTitleMessageAndButton( "Error Loading Texture.  Did you choose a photo first?", error, "OK" );
		Fugu.Log.Warn( "textureLoadFailed: " + error );
	}
#endif

#if UNITY_ANDROID && P31_ETC

		void Start()
		{
			EtceteraAndroidManager.photoChooserSucceededEvent += photoChooserSucceededEvent;
			EtceteraAndroidManager.albumChooserSucceededEvent += albumChooserSucceededEvent;
		}
		
		void photoChooserSucceededEvent( string imagePath )
		{
			textureLoaded ( EtceteraAndroid.textureFromFileAtPath(imagePath ) );
			//textureLoaded(tex);
		}
		
		void albumChooserSucceededEvent( string imagePath )
		{
			textureLoaded( EtceteraAndroid.textureFromFileAtPath(imagePath) );
			//textureLoaded(tex);
		}


/*	void Start()
	{
		EtceteraAndroidManager.photoChooserSucceededEvent += photoChooserSucceededEvent;
		EtceteraAndroidManager.albumChooserSucceededEvent += albumChooserSucceededEvent;
	}

	void photoChooserSucceededEvent( Texture2D tex )
	{
		textureLoaded(tex);
	}

	void albumChooserSucceededEvent( Texture2D tex )
	{
		textureLoaded(tex);
	} */
#endif

	// Texture loading delegates
	public void textureLoaded( Texture2D texture )
	{
		Fugu.Log.Info("Setting the main texture of "+gameObject.name);
		SetMainTexture(texture);
	}
}
}