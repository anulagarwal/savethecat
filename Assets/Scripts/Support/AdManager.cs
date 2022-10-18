using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdManager : MonoBehaviour
{
    [SerializeField] bool showBanner = false;
    [SerializeField] float cooldown;
    // Start is called before the first frame update
    void Start()
    {

        Appodeal.initialize("7b253773af88baeda62a091c7297a967875f690930d3c0ca", Appodeal.BANNER_BOTTOM);
        Appodeal.setSmartBanners(true);
        Appodeal.initialize("7b253773af88baeda62a091c7297a967875f690930d3c0ca", Appodeal.INTERSTITIAL);



    }

    public void ShowBanner()
    {
        if (showBanner)
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
            
        }
    }

    public void ShowInterstitial()
    {
        Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void HideBanner()
    {
        Appodeal.hide(Appodeal.BANNER_BOTTOM);

    }


}
