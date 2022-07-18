using UnityEngine;
using System.Collections;

namespace Hyper {

public class ScoreTotal : MonoBehaviour {

	
		
		public int frame=0;
		
		public int player=0;
		
		void Play () {
			string text = "";
			int total = Bowl.GetScore(frame,player);
			if (total>-1) {
				text = total.ToString();
			}
			TextMesh mesh = GetComponent<TextMesh>();
			mesh.text = text;
		} 
		

}

}