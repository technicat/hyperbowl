using UnityEngine;
using System.Collections;

namespace Hyper {
public class ScoreBall2 : MonoBehaviour {

		public GameObject[] digits;

		public int frame=0;

		public GameObject spare;

		public int hyperplayer = 0;

		private Hashtable htstart;
		private Hashtable htend;

		void Awake ()
			{
				htstart=iTween.Hash("onstart","StartAnim","oncomplete","PlayEnd","delay",1,"position", new Vector3(0f,-0.01f,0.95f),"time",1,"easetype",iTween.EaseType.easeOutQuad);
				htend=iTween.Hash("delay",1,"position",transform.position,"time",1,"easetype",iTween.EaseType.easeInOutQuad);
			}

		void Play () {
				for (int i=0; i<digits.Length; ++i) {
					digits[i].SetActive(false);
				}
				spare.SetActive(false);
				if (frame == Bowl.frame && Bowl.roll == 1 && Bowl.currentplayer == hyperplayer) {
					PlayStart();
				} else {
					ActivateSpareOrDigit();
				}
			}

			void StartAnim() {
				transform.position = Vector3.zero;
				ActivateSpareOrDigit(); // do this after moving
			}

			void ActivateSpareOrDigit() {
				if (Bowl.IsSpare(frame,hyperplayer)) {
					spare.SetActive(true);
				} else {
					ActivateDigit();
				}
			}

			void ActivateDigit() {
				int score = Bowl.GetCurrentScores(hyperplayer)[frame].ball2;
				if (score>-1) {
					digits[score].SetActive(true);
				}
			}

			void PlayStart() {
				iTween.MoveTo(gameObject,htstart);
			}

			void PlayEnd() {
				iTween.MoveTo(gameObject,htend);
			}
	
	}
}
