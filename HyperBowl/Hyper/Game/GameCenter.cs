/* Copyright Technicat LLC */

using UnityEngine;
using System.Collections;

namespace Hyper {

  // should rename this to avoid confusion with Fugu.GameCenter?
	public class GameCenter {

    static public void Score(int lane,long score) {
      #if UNITY_IOS || UNITY_TVOS || STEAM
       if (lane <= leaderboards.Length) {
	      Fugu.GameCenter.Score(leaderboards[lane-1],score);
       }
       #endif
    }

   
   
    static public void AchievementLane(int lane, int complete) {
       #if UNITY_IOS || UNITY_TVOS || STEAM
       if (lane <= laneAchievements.Length) {
	      Fugu.GameCenter.Achievement(laneAchievements[lane-1], complete);
       }
       #endif
    }

     static public void AchievementDifficulty(int difficulty, int complete) {
       #if UNITY_IOS || UNITY_TVOS || STEAM
        if (difficulty < difficultyAchievements.Length) {
	         Fugu.GameCenter.Achievement(difficultyAchievements[difficulty], complete);
        }
        #endif
    }

#if UNITY_IOS || UNITY_TVOS

static public string[] leaderboards={

"grp.com.technicat.HyperBowl.lane1.free", // classic
"grp.com.technicat.HyperBowl.lane2.free", // rome
"grp.com.technicat.HyperBowl.lane3.free", // forest
"grp.com.technicat.HyperBowl.lane4.free", // high seas
"grp.com.technicat.HyperBowl.lane5.free", // san francisco
"grp.com.technicat.HyperBowl.lane6.free", // tokyo
"grp.com.technicat.HyperBowl.lane7.free", // penelope
"grp.com.technicat.HyperBowl.lane8.free", // snowpark
"grp.com.technicat.HyperBowl.lane9.free", // mushroom
"grp.com.technicat.HyperBowl.lane10.free", // campfire
// campfire is the last one that we have a GameCenter leaderboard 

		};

		static public string[] laneAchievements={
"CgkIg8XpiJUWEAIQCg", // classic
"CgkIg8XpiJUWEAIQCw", // rome
"CgkIg8XpiJUWEAIQDA", // forest
"CgkIg8XpiJUWEAIQDQ", // high seas
"CgkIg8XpiJUWEAIQDg", // sf
"CgkIg8XpiJUWEAIQDw", // tokyo
"CgkIg8XpiJUWEAIQEA", // penelope
"CgkIg8XpiJUWEAIQEQ", // snowpark
"CgkIg8XpiJUWEAIQEg", // mushroom
"CgkIg8XpiJUWEAIQIA" // campfire
// campfire is the last one that we have a GameCenter leaderboard 
		};

		static public string[] difficultyAchievements={
	"grp.com.technicat.hyperbowl.novice",
	"grp.com.technicat.hyperbowl.intermediate",	
	"grp.com.technicat.hyperbowl.expert"
		};

		static public string[] strikeAchievements = {
	"grp.com.technicat.hyperbowl.strike",
	"grp.com.technicat.hyperbowl.double",
	"grp.com.technicat.hyperbowl.turkey",
	"grp.com.technicat.hyperbowl.hambones",
	"grp.com.technicat.hyperbowl.yahtzee",
	"grp.com.technicat.hyperbowl.wildturkeys"
		};

static public string scoreAchievement = "grp.com.technicat.hyperbowl.perfect";
#endif

#if STEAM 

	static public string[] leaderboards={
       "classic",
          "rome",
          "forest",
          "ship",
          "sanfrancisco",
          "tokyo",
          "penelope",
          "snowpark",
          "mushroom",
          "campfire",
          "grasspier"

		};

    	static public string[] laneAchievements={
         

		};

		static public string[] difficultyAchievements={
	
		};

		static public string[] strikeAchievements = {
		};

		static public string scoreAchievement = null;

#endif

#if (UNITY_ANDROID && !GOOGLE) || UNITY_WEBGL
static public string[] leaderboards={

		};

    	static public string[] laneAchievements={

		};

		static public string[] difficultyAchievements={
	
		};

		static public string[] strikeAchievements = {
		};

		static public string scoreAchievement = null;
#endif

#if GOOGLE // GPGS

		static public string[] difficultyAchievements= {
"CgkIg8XpiJUWEAIQEw", // novice
"CgkIg8XpiJUWEAIQFA", // intermediate
"CgkIg8XpiJUWEAIQFQ" // expert
		};

		static public string[] strikeAchievements ={
"CgkIg8XpiJUWEAIQAw", // strike
"CgkIg8XpiJUWEAIQBA", // double
"CgkIg8XpiJUWEAIQBQ", // turkey
"CgkIg8XpiJUWEAIQBg", // hambones
"CgkIg8XpiJUWEAIQBw", // yahtzee
"CgkIg8XpiJUWEAIQCA", // wildturkeys
		};

		static public string[] leaderboards={
"CgkIg8XpiJUWEAIQFw", // classic
"CgkIg8XpiJUWEAIQGA", // rome
"CgkIg8XpiJUWEAIQGQ", // forest
"CgkIg8XpiJUWEAIQGg", // high seas
"CgkIg8XpiJUWEAIQGw", // san francisco
"CgkIg8XpiJUWEAIQHA", // tokyo
"CgkIg8XpiJUWEAIQHg", // penelope
"CgkIg8XpiJUWEAIQHQ", // snowpark
"CgkIg8XpiJUWEAIQHw", // mushroom
"CgkIg8XpiJUWEAIQIA" // campfire
		};

		static public string[] laneAchievements={
"CgkIg8XpiJUWEAIQCg", // classic
"CgkIg8XpiJUWEAIQCw", // rome
"CgkIg8XpiJUWEAIQDA", // forest
"CgkIg8XpiJUWEAIQDQ", // high seas
"CgkIg8XpiJUWEAIQDg", // sf
"CgkIg8XpiJUWEAIQDw", // tokyo
"CgkIg8XpiJUWEAIQEA", // penelope
"CgkIg8XpiJUWEAIQEQ", // snowpark
"CgkIg8XpiJUWEAIQEg", // mushroom
"CgkIg8XpiJUWEAIQIA" // campfire
		};

		static public string scoreAchievement = "";

#endif

}
}

/*

<?xml version="1.0" encoding="utf-8"?>
<!--
Google Play game services IDs.
Save this file as res/values/games-ids.xml in your project.
-->
<resources>
  <!-- app_id -->
  <string name="app_id" translatable="false">761569895043</string>
  <!-- package_name -->
  <string name="package_name" translatable="false">com.technicat.HyperBowlPro</string>
  <!-- achievement Spare -->
  <string name="achievement_spare" translatable="false">CgkIg8XpiJUWEAIQAg</string>
  <!-- achievement Strike -->
  <string name="achievement_strike" translatable="false">CgkIg8XpiJUWEAIQAw</string>
  <!-- achievement Double -->
  <string name="achievement_double" translatable="false">CgkIg8XpiJUWEAIQBA</string>
  <!-- achievement Turkey -->
  <string name="achievement_turkey" translatable="false">CgkIg8XpiJUWEAIQBQ</string>
  <!-- achievement Hambones -->
  <string name="achievement_hambones" translatable="false">CgkIg8XpiJUWEAIQBg</string>
  <!-- achievement Yahtzee -->
  <string name="achievement_yahtzee" translatable="false">CgkIg8XpiJUWEAIQBw</string>
  <!-- achievement Wild Turkeys -->
  <string name="achievement_wild_turkeys" translatable="false">CgkIg8XpiJUWEAIQCA</string>
  <!-- achievement Perfect Game -->
  <string name="achievement_perfect_game" translatable="false">CgkIg8XpiJUWEAIQCQ</string>
  <!-- achievement Novice -->
  <string name="achievement_novice" translatable="false">CgkIg8XpiJUWEAIQEw</string>
  <!-- achievement Intermediate -->
  <string name="achievement_intermediate" translatable="false">CgkIg8XpiJUWEAIQFA</string>
  <!-- achievement Expert -->
  <string name="achievement_expert" translatable="false">CgkIg8XpiJUWEAIQFQ</string>
  <!-- achievement Classic -->
  <string name="achievement_classic" translatable="false">CgkIg8XpiJUWEAIQCg</string>
  <!-- achievement Rome -->
  <string name="achievement_rome" translatable="false">CgkIg8XpiJUWEAIQCw</string>
  <!-- achievement Forest -->
  <string name="achievement_forest" translatable="false">CgkIg8XpiJUWEAIQDA</string>
  <!-- achievement High Seas -->
  <string name="achievement_high_seas" translatable="false">CgkIg8XpiJUWEAIQDQ</string>
  <!-- achievement San Francisco -->
  <string name="achievement_san_francisco" translatable="false">CgkIg8XpiJUWEAIQDg</string>
  <!-- achievement Tokyo -->
  <string name="achievement_tokyo" translatable="false">CgkIg8XpiJUWEAIQDw</string>
  <!-- achievement Penelope -->
  <string name="achievement_penelope" translatable="false">CgkIg8XpiJUWEAIQEA</string>
  <!-- achievement Snowpark -->
  <string name="achievement_snowpark" translatable="false">CgkIg8XpiJUWEAIQEQ</string>
  <!-- achievement Mushroom -->
  <string name="achievement_mushroom" translatable="false">CgkIg8XpiJUWEAIQEg</string>
  <!-- achievement Campfire -->
  <string name="achievement_campfire" translatable="false">CgkIg8XpiJUWEAIQIQ</string>
  <!-- leaderboard Scores -->
  <string name="leaderboard_scores" translatable="false">CgkIg8XpiJUWEAIQFg</string>
  <!-- leaderboard Classic -->
  <string name="leaderboard_classic" translatable="false">CgkIg8XpiJUWEAIQFw</string>
  <!-- leaderboard Rome -->
  <string name="leaderboard_rome" translatable="false">CgkIg8XpiJUWEAIQGA</string>
  <!-- leaderboard Forest -->
  <string name="leaderboard_forest" translatable="false">CgkIg8XpiJUWEAIQGQ</string>
  <!-- leaderboard High Seas -->
  <string name="leaderboard_high_seas" translatable="false">CgkIg8XpiJUWEAIQGg</string>
  <!-- leaderboard San Francisco -->
  <string name="leaderboard_san_francisco" translatable="false">CgkIg8XpiJUWEAIQGw</string>
  <!-- leaderboard Tokyo -->
  <string name="leaderboard_tokyo" translatable="false">CgkIg8XpiJUWEAIQHA</string>
  <!-- leaderboard Snowpark -->
  <string name="leaderboard_snowpark" translatable="false">CgkIg8XpiJUWEAIQHQ</string>
  <!-- leaderboard Penelope -->
  <string name="leaderboard_penelope" translatable="false">CgkIg8XpiJUWEAIQHg</string>
  <!-- leaderboard Mushroom Land -->
  <string name="leaderboard_mushroom_land" translatable="false">CgkIg8XpiJUWEAIQHw</string>
  <!-- leaderboard Campfire -->
  <string name="leaderboard_campfire" translatable="false">CgkIg8XpiJUWEAIQIA</string>
</resources>

 */