using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hyper {

public class AdsOnly : MonoBehaviour
{
    void Start()
    {
        #if !HYPER_ADS
        gameObject.SetActive(false);
        #endif
    }

}

}