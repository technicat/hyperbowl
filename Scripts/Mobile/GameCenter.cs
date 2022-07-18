// wrapper around game network
// GameCenter, Google Play Game Services, Steam..

using UnityEngine;

#if STEAM
using Steamworks;
#endif

namespace Fugu {
	
	sealed public class GameCenter : MonoBehaviour {

		public bool showAchievementBanners = true;

		static private Texture2D profilePhoto = null;

		static public void Achievement(string name, float progress) {
			if (authenticated) {
				ReportAchievement(name,progress);
				}
		}

#if UNITY_IOS  || UNITY_TVOS
	
		void Start () {
			if (!authenticated) { // if this level restarts then we'll have repeated authentications
		Social.localUser.Authenticate ( success => {
      	  if (success) {
					Log.Warn("Authenticated "+Social.localUser.userName);
					profilePhoto = Social.localUser.image;
				UnityEngine.SocialPlatforms.GameCenter.GameCenterPlatform.ShowDefaultAchievementCompletionBanner(showAchievementBanners);
        	}
			else {
				Log.Warn ("Failed to authenticate "+Social.localUser.userName);
			}
		}
    	);
			}
	}
#endif

#if GPGS
	
		void Start () {
	 GooglePlayGames.PlayGamesPlatform.Activate();
			if (!authenticated) { // if this level restarts then we'll have repeated authentications
		Social.localUser.Authenticate ( success => {
      	  if (success) {
					profilePhoto = Social.localUser.image;
        	}
			else {
				Log.Warn ("Failed to authenticate "+Social.localUser.userName);
			}
		}
    	);
			}
	}
#endif

		/* public void SetProfileImage( Texture2D texture )
		{
			profilePhoto = texture;
		} */

		public void textureLoadFailed( string error )
		{
			Fugu.Log.Warn( "unable to load profile pic: " + error );
		}


	static public void Achievement(string name) {
			Achievement(name,100.0f);
		}
		
	static public void ReportAchievement(string name, float progress) {
#if UNITY_IOS || UNITY_TVOS || GPGS
			Social.ReportProgress(name,progress, success => {
			if (success) {
				Log.Info("Achievement "+name+" reported successfully");
			} else {
				Log.Warn("Failed to report achievement "+name);
			}
		});
#endif

#if STEAM
 // put steam achievemen there
#endif

}

	static public void Score(string name,long score) {
			if (authenticated) {
#if UNITY_IOS || UNITY_TVOS || GPGS
			  Social.ReportScore (score, name, success => {
			if (success) {
				Log.Info("Posted "+score+" on leaderboard "+name);
			} else {
				Log.Warn("Failed to post "+score+" on leaderboard "+name);
			}
		});
#endif
#if STEAM
#endif
			}
}

// change this to a reader
	static public bool authenticated {
		get {
#if UNITY_IOS || UNITY_TVOS || GPGS
			return Social.localUser.authenticated;
#endif
#if STEAM 
return SteamManager.Initialized; // false; // true;
#endif
return false;
		}
	}

		static public string playerName {
			get {
			if (!authenticated) {
				return "Player";
			} else {
				#if UNITY_IOS || UNITY_TVOS || GPGS
				return Social.localUser.userName;
				#endif
				#if STEAM
				return SteamFriends.GetPersonaName();
				#endif
				return "Player";
			}
		}
		}

		static public Texture2D photo {
			get {
			if (!authenticated || playerName == "") {
				return null;
			} else {
				return profilePhoto;
			}
		}
		}

		static public void ShowLeaderboard() {
#if UNITY_IOS || TVOS || GPGS
			Social.ShowLeaderboardUI ();
#endif
#if STEAM 
#endif
		}

		static public void ShowAchievements() {
#if UNITY_IOS || UNITY_TVOS || GPGS
			Social.ShowAchievementsUI ();
#endif
#if STEAM 
#endif
		}

}

}
