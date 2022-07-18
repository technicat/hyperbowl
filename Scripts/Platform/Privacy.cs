using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace Fugu {


public class Privacy : MonoBehaviour {

    void OnFailure(string reason)
    {
//        Debug.LogWarning(String.Format("Failed to get data privacy page URL: {0}", reason));
    }

    void OnURLReceived(string url)
    {
        Platform.OpenWebPage(url);
       // Application.OpenURL(url);
    }

    public void OpenDataURL()
    {
        DataPrivacy.FetchPrivacyUrl(OnURLReceived, OnFailure);
    }

    /* void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            OpenDataURL();
        }
    } */
}
}
