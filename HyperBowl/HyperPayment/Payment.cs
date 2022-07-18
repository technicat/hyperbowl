using UnityEngine;
using System.Collections;

namespace Hyper {
public class Payment : FrontEnd {

		override public void Awake () {
			base.Awake();
			nextLevel = "HyperTextEntry";
		Game.numplayers = 1;
		}

	}
}
