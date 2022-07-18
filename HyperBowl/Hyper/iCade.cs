using UnityEngine;
using System.Collections;

namespace Hyper {

public class iCade : MonoBehaviour {
#if UNITY_IPHONE && P31_ICADE

		static public bool useiCade = false;
		
		static public void SetActive(bool b) {
			useiCade = b;
			iCadeBinding.setActive(b);
		}
		
		static public bool ButtonPressed() {
			return useiCade && (iCadeBinding.state.ButtonA || iCadeBinding.state.ButtonB || iCadeBinding.state.ButtonC || iCadeBinding.state.ButtonD ||
			                            iCadeBinding.state.ButtonE || iCadeBinding.state.ButtonF || iCadeBinding.state.ButtonG || iCadeBinding.state.ButtonH);
		}
		
		public void Awake () {
			SetActive(true);
		}
		
		public void Update () {
			if (useiCade) {
				iCadeBinding.updateState();
			}
		}
		
		#endif
		

}

}