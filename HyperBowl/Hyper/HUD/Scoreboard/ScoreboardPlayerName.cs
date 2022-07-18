using UnityEngine;
using System.Collections;

namespace Hyper {
public class ScoreboardPlayerName : MonoBehaviour {

			public int playernum = 0;

		private TextMesh playername;

			void Awake() {
			playername = GetComponent<TextMesh>();
			}

			void Play() {
				if (playername != null) {
					playername.text = Bowl.GetPlayerName(playernum);
				}
			}

	}
}
