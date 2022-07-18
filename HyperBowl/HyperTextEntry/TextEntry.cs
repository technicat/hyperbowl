using UnityEngine;
using System.Collections;

using TMPro;

namespace Hyper {
	
public class TextEntry : Hyper.FrontEnd  {

		public GameObject playernamedisplay;

		public GameObject textentry;

		private string playerkey = "";

		override public void Awake ()  {
			base.Awake();
			TMP_Text text3d = playernamedisplay.GetComponent<TMP_Text>();
			text3d.text = "PLAYER "+(Bowl.currentplayer+1);
			//
			playerkey = "Player"+(Bowl.currentplayer+1)+"Name";
			Key.entry = PlayerPrefs.GetString(playerkey,"HyperBowler"+(Bowl.currentplayer+1));
		}

		override protected IEnumerator WipeClose() {
			PlayerPrefs.SetString(playerkey,Key.entry);
			if (Bowl.currentplayer < Game.numplayers-1) {
				//	state = "PlayerInit";
				++Bowl.currentplayer;
				nextLevel = "HyperTextEntry";
			} else {
				//	state="NextLevel";
				nextLevel = "HyperSelect";
			}
			yield return base.WipeClose();
		}

	}
}
