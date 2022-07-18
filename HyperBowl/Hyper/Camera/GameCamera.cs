using UnityEngine;
using System.Collections;

// viewport for all game (non-background) cameras
namespace Hyper {
	
public class GameCamera : MonoBehaviour {

		int lastScreenHeight = 0;
		int lastScreenWidth =0;
		bool lastfullscreen = false;

		// classic sbackground image
		int backWidth = 800;
		int backHeight = 600;

		// position of game rect inside classic background image
		int width = 448;
		int height = 587;
		int left = 170;
		int top =  6;

void Awake () {

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
			Camera cam = GetComponent<Camera>();
		cam.eventMask = 0;
#endif
			// use custom def?
#if FUGU_BACKGROUND // UNITY_STANDALONE || UNITY_WSA || FIRETV || UNITY_TVOS || UNITY_WEBGL
			// _OSX || UNITY_STANDALONE_WIN || UNITY_NACL || UNITY_STANDALONE_LINUX
		//	Camera cam = GetComponent<Camera>();
//	cam.pixelRect = new Rect(170,6,448,587);
			SetRect();
#endif
	}

		//#if FUGU_BACKGROUND // UNITY_STANDALONE || UNITY_WSA || FIRETV || UNITY_TVOS || UNITY_WEBGL
		// center the pixel rect
		void SetRect() {
				lastScreenWidth = Screen.width;
				lastScreenHeight = Screen.height;
			lastfullscreen = Screen.fullScreen;
			Camera cam = GetComponent<Camera>();
		/*	int width = 448;
			int height = 587;
			int left = 170;
			int top =  6; */
			//  center
			//int left = (Screen.width-width)/2; // 170;
			//int top = (Screen.height-height)/2; // 6;
			cam.pixelRect = new Rect(left+(Screen.width-backWidth)/2, top+(Screen.height-backHeight)/2, width, height);
			float aspect = (float)backWidth/(float)backHeight;
			float scale = 1;
			if (((float)Screen.width/(float)Screen.height) > aspect) {
				scale = (float)Screen.height/(float)backHeight;
			} else {
				scale = (float)Screen.width/(float)backWidth;
			}
			cam.pixelRect = new Rect(scale*left+(Screen.width-backWidth*scale)/2, scale*top+(Screen.height-backHeight*scale)/2, scale*width, scale*height);
		}
	
	#if FUGU_BACKGROUND
		void Update()
		{
			// check the screen height and witdh
			if ((Screen.height != lastScreenHeight) || (Screen.width != lastScreenWidth) || (Screen.fullScreen != lastfullscreen)) 
			{
				SetRect();
			}
		}
		#endif

	}
}

	/*
public class GameCamera : MonoBehaviour {
	int lastScreenHeight  = 0;
	int lastScreenWidth  = 0;
	bool lastfullscreen = false;
		float _wantedAspectRatio = .75f; // 448f/547f; // 1.777778f; // (16:9)
	// public float _wantedAspectRatio = 1.3333333f; // 4:3
	 bool landscapeModeOnly = false;
	bool _landscapeModeOnly = true;
	float wantedAspectRatio;
	Camera cam;
	Camera backgroundCam;

	void Awake () {
		Screen.fullScreen = true;
		_landscapeModeOnly = landscapeModeOnly;
		cam = GetComponent<Camera>();
		if (!cam) {
			cam = Camera.main;
			//Debug.Log ("Setting the main camera " + cam.name);
		}
		else {
			//Debug.Log ("Setting the main camera " + cam.name);
		}

		if (!cam) {
			//Debug.LogError ("No camera available");
			return;
		}
		wantedAspectRatio = _wantedAspectRatio;
		SetCamera();
	}

	void Update()
	{
		// check the screen height and witdh
		if ((Screen.height != lastScreenHeight) || (Screen.width != lastScreenWidth) || (Screen.fullScreen != lastfullscreen)) 
		{
			lastScreenWidth = Screen.width;
			lastScreenHeight = Screen.height;
			lastfullscreen = Screen.fullScreen;
			SetCamera();
		}
	}

	public void SetCamera () {
			#if UNITY_STANDALONE || UNITY_WSA || FIRETV || UNITY_TVOS
		float currentAspectRatio = 0.0f;
		if(Screen.orientation == ScreenOrientation.LandscapeRight ||
			Screen.orientation == ScreenOrientation.LandscapeLeft) {
			//Debug.Log ("Landscape detected...");
			currentAspectRatio = (float)Screen.width / Screen.height;
		}
		else {
			//Debug.Log ("Portrait detected...?");
			if(Screen.height  > Screen.width && _landscapeModeOnly) {
				currentAspectRatio = (float)Screen.height / Screen.width;
			}
			else {
				currentAspectRatio = (float)Screen.width / Screen.height;
			}
		}
		// If the current aspect ratio is already approximately equal to the desired aspect ratio,
		// use a full-screen Rect (in case it was set to something else previously)

		// Debug.Log ("currentAspectRatio = " + currentAspectRatio + ", wantedAspectRatio = " + wantedAspectRatio);

		if ((!Screen.fullScreen) && ((int)(currentAspectRatio * 100) / 100.0f == (int)(wantedAspectRatio * 100) / 100.0f)) 
		{
			cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
			if (backgroundCam) {
				Destroy(backgroundCam.gameObject);
			}
			return;
		}

		// Pillarbox
		if (currentAspectRatio > wantedAspectRatio) {
			float inset = 1.0f - wantedAspectRatio/currentAspectRatio;
			cam.rect = new Rect(inset/2, 0.0f, 1.0f-inset, 1.0f);
		}
		// Letterbox
		else {
			float inset = 1.0f - currentAspectRatio/wantedAspectRatio;
			cam.rect = new Rect(0.0f, inset/2, 1.0f, 1.0f-inset);
		}
		if (!backgroundCam) {
			// Make a new camera behind the normal camera which displays black; otherwise the unused space is undefined
			backgroundCam = new GameObject("BackgroundCam", typeof(Camera)).GetComponent<Camera>();
			backgroundCam.depth = int.MinValue;
			// backgroundCam.clearFlags = CameraClearFlags.SolidColor;
			backgroundCam.clearFlags = CameraClearFlags.Skybox;
			backgroundCam.backgroundColor = Color.black;
			backgroundCam.cullingMask = 0;
		}

			#endif
	}

	 int screenHeight {
		get {
			return (int)(Screen.height * cam.rect.height);
		}
	}

 int screenWidth {
		get {
			return (int)(Screen.width * cam.rect.width);
		}
	}

	 int xOffset {
		get {
			return (int)(Screen.width * cam.rect.x);
		}
	}

	 int yOffset {
		get {
			return (int)(Screen.height * cam.rect.y);
		}
	}

 Rect screenRect {
		get {
			return new Rect(cam.rect.x * Screen.width, cam.rect.y * Screen.height, cam.rect.width * Screen.width, cam.rect.height * Screen.height);
		}
	}

	 Vector3 mousePosition {
		get {
			Vector3 mousePos = Input.mousePosition;
			mousePos.y -= (int)(cam.rect.y * Screen.height);
			mousePos.x -= (int)(cam.rect.x * Screen.width);
			return mousePos;
		}
	}

	 Vector2 guiMousePosition {
		get {
			Vector2 mousePos = Event.current.mousePosition;
			mousePos.y = Mathf.Clamp(mousePos.y, cam.rect.y * Screen.height, cam.rect.y * Screen.height + cam.rect.height * Screen.height);
			mousePos.x = Mathf.Clamp(mousePos.x, cam.rect.x * Screen.width, cam.rect.x * Screen.width + cam.rect.width * Screen.width);
			return mousePos;
		}
	}
} 
} */