using UnityEngine;
using System.Collections;

namespace Hyper {
public class Select : Lane {

		public GameObject[] runways;

		public string[] levels = {"HyperSelect2","HyperTokyo","HyperSF","HyperClassic","HyperRoman","HyperForest","HyperShip","HyperMenu"};
	
		public bool startPaused = true;

	private float selectZ = -1; // lane selection boundary

	override public IEnumerator WipeOpen() {
		yield return base.WipeOpen();
		ball.SetActive(true);
		StartRolling();
			#if !UNITY_TVOS
			if (startPaused) {
				Fugu.PauseMenu.PauseGame();
			}
			#endif
		state = "StateRoll";
	}

	IEnumerator StateRoll() {
		GameObject runway = null;
		int lane = 3;
		while (true) {
				if (checkQuit()) { // Quit.quitGame) {
				Fugu.Platform.UnlockCursor();
					yield break;
			//	nextLevel = Bowl.HyperMenu();
			//	state="WipeClose";
			//	break;
			}
			if ((ball.transform.position.z<selectZ) || (timer != null && TimerPause.IsTimedOut())) {
				// if (lane == 0) {
				//	nextLevel = randomLevels[Random.Range(0,randomLevels.length)];
				//} else {
				nextLevel = levels[lane];
				//}
				state="WipeClose";
				break;
				}
				lane = (int)Mathf.Floor(ball.transform.position.x/10f)+4;
			if (lane<0) lane = 0;
			if (lane>7) lane = 7;
			if (runway != runways[lane]) {
				if (runway != null) {
					runway.SetActive(false);
				}
				runway = runways[lane];
				if (runway != null) {
					runway.SetActive(true);
				}
				}
				yield return null;
			}
	}

}

}