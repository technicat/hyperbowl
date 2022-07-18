using UnityEngine;
using System.Collections;

#if FUGU_VIDEO_ADS
using UnityEngine.Advertisements;
#endif

using Fugu;

namespace Hyper {
public class Trophy : FrontEnd {


		public GameObject tiebox;
		public GameObject[] scorebox;

		public GameObject topscorebox;

		static public int[] scores;
		static public string[] names;

			override public void Awake() {
					base.Awake();
			nextLevel = StartScene;
					scores = new int[Game.numplayers];
					names = new string[Game.numplayers];
					for (int i=0; i<Game.numplayers; ++i) {
					string playername = Bowl.GetPlayerName(i);
					int playerscore = Bowl.GetScore(9,i);
						// need to sort
						scores[i]=playerscore;
						names[i]=playername;
						// sort
						for (int j=i; j>0;--j) {
							if (scores[j]>scores[j-1]) {
								// swap
								var tempname = names[j];
								var tempscore = scores[j];
								scores[j]=scores[j-1];
								names[j]=names[j-1];
								scores[j-1]=tempscore;
								names[j-1]=tempname;
							} else {
								break;
							}
						}
					}
					// assume all scoreboxes start out disabled
					if (IsTieGame()) {
						tiebox.SetActive(true);
						for (int p=0; p<Game.numplayers-1; ++p) {
							scorebox[p].SetActive(true);
						}
						topscorebox.SetActive(false);
					} else {
						for (int q=0; q<Game.numplayers; ++q) {
							scorebox[q].SetActive(true);
						}
					}
				}
			
		override public IEnumerator WipeOpen() {
				yield return base.WipeOpen();
				Platform.RequestReview();
				}


	
		#if HYPER_ADS
		override protected IEnumerator WipeClose() {
			Fugu.Ads.ShowAd();
			yield return base.WipeClose();
		}
			#endif

				static public bool IsTieGame() {
					return Game.numplayers>1 && scores[0]==scores[1];
				}
			}
	
	}

