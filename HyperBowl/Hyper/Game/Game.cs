

namespace Hyper {


public class Game
{
    public enum Mode {
		ARCADE, // the original
		GAMECENTER, // single-player on game networks (GameCenter, GPGS, Steam...)
	}

	// game mode

	#if UNITY_IOS || UNITY_TVOS || STEAM || GPGS
	static public Mode mode = Mode.GAMECENTER; // should be single-player? but implies connection
	#else
	static public Mode mode = Mode.ARCADE;
	#endif

	static public int numplayers = 1;
	// number of players - 1-4

#if UNITY_WEBGL
	static public bool pro = false;
#else
	static public bool pro = true;
#endif
}

}