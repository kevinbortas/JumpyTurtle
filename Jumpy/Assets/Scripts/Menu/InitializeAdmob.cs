using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InitializeAdmob : MonoBehaviour
{

    private BannerView bannerView;

    void Start()
    {
        #if UNITY_ANDROID
            string appId = "ca-app-pub-6571494935842226~1047395465";
        #elif UNITY_IPHONE
            string appId = "ca-app-pub-6571494935842226~6011005583";
        #else
            string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    public void RequestBanner()
    {
        #if UNITY_ANDROID // Real ad-unit ca-app-pub-6571494935842226/8419291474
            string adUnitId = "ca-app-pub-6571494935842226/8419291474";
        #elif UNITY_IPHONE // Real ad-unit ca-app-pub-6571494935842226/3022961734
            string adUnitId = "ca-app-pub-6571494935842226/3022961734";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        AdSize adSize = new AdSize(468, 60);

        this.bannerView = new BannerView(adUnitId, adSize, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void DestroyBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
    }
}
