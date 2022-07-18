using UnityEngine;
using System.Collections;

namespace Hyper {
public class TrophyScore : MonoBehaviour {
		
			public int hyperplayer = 0;

			void Start () {
				int score;
				score = Trophy.scores[hyperplayer];
			TextMesh text3d = GetComponent<TextMesh>();
				text3d.text = score.ToString();
			}
	
	}
}
