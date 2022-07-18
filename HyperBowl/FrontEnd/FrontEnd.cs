using UnityEngine;
using System.Collections;

namespace Hyper {
	abstract public class FrontEnd : FSM {

		// states
		
	override public IEnumerator WipeOpen() {
			yield return base.WipeOpen();
			Fugu.Platform.UnlockCursor();
			state = "WaitForButton";
		}

		override protected IEnumerator WipeClose() {
			ButtonCam.SetActive(false);
			yield return base.WipeClose();
		}
		
	virtual protected IEnumerator WaitForButton() {
			Button.buttonpressed = false;
			ButtonCam.SetActive(true);
			while (!Hyper.Button.buttonpressed && !Hyper.Quit.quitGame) {
				yield return null;
			}
			state = "WipeClose";
		}
	
}
}
