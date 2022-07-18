using UnityEngine;
using System.Collections;

namespace Hyper {
	
public class Logo : FrontEnd {

		override public void Awake() {
			base.Awake();
			nextLevel = StartScene;
		}

		// states

/*
		protected override IEnumerator WaitForButton () {
			#if OBB
			GUIText text = GetComponent<GUIText>();
			var expPath:String = GooglePlayDownloader.GetExpansionFilePath();
			if (expPath == null)
			{
			text.text = "External storage is not available!";
			}
			else
			{
			var mainPath:String = GooglePlayDownloader.GetMainOBBPath(expPath);
			var patchPath:String = GooglePlayDownloader.GetPatchOBBPath(expPath);

			text.text =  "Main = ..."  + ( mainPath == null ? " NOT AVAILABLE" :  mainPath.Substring(expPath.Length));
			text.text = "Patch = ..." + (patchPath == null ? " NOT AVAILABLE" : patchPath.Substring(expPath.Length));
			if (mainPath == null || patchPath == null)
			GooglePlayDownloader.FetchOBB();
			}

			#endif
			yield return base.WaitForButton();
		}
*/

	}
}
