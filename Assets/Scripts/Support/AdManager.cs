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
        Appodeal.setAutoCache(Appodeal.INTERSTITIAL, false);
        Appodeal.initialize("7b253773af88baeda62a091c7297a967875f690930d3c0ca", Appodeal.BANNER_BOTTOM);
        Appodeal.setSmartBanners(true);
        Appodeal.initialize("7b253773af88baeda62a091c7297a967875f690930d3c0ca", Appodeal.INTERSTITIAL);      

    }

    #region Appodeal
    public void LoadAd()
    {
        Appodeal.cache(Appodeal.INTERSTITIAL);
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

    #endregion

    void Awake()
    {
        
    }

    public void OnResumeGame()
    {
        // RESUME MY GAME
    }

    public void OnPauseGame()
    {
        // PAUSE MY GAME
    }

    public void OnRewardGame()
    {
        // REWARD PLAYER HERE
    }

    public void OnRewardedVideoSuccess()
    {
        // Rewarded video succeeded/completed.;
        GameManager.Instance.AddFinalInk();
    }

    public void OnRewardedVideoFailure()
    {
        // Rewarded video failed.;
    }

    public void OnPreloadRewardedVideo(int loaded)
    {
        // Feedback about preloading ad after called GameDistribution.Instance.PreloadRewardedAd
        // 0: SDK couldn't preload ad
        // 1: SDK preloaded ad
       
    }

    public void ShowAd()
    {
        //GameDistribution.Instance.ShowAd();
    }

    public void ShowRewardedAd()
    {
        //GameDistribution.Instance.ShowRewardedAd();
    }

    public void PreloadRewardedAd()
    {
        //GameDistribution.Instance.PreloadRewardedAd();
    }
}
