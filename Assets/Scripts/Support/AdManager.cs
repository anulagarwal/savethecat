using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdManager : MonoBehaviour
{
    [SerializeField] bool showBanner = false;
    // Start is called before the first frame update
    void Start()
    {
        Appodeal.initialize("7b253773af88baeda62a091c7297a967875f690930d3c0ca", Appodeal.BANNER_BOTTOM);

        if (showBanner)
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
