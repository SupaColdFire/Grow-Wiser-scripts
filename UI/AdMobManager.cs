using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdMobManager : MonoBehaviour
{
    private const string appId = "ca-app-pub-3501625654415985~7227767149";

    private string _bannerAd = "Banner";

    private BannerView _bannerView;

    private void Start()
    {
        MobileAds.Initialize(appId);
        RequestBanner();
        DisplayBanner();
    }

    private void RequestBanner()
    {
        var adUnitId = "ca-app-pub-3501625654415985/5232159196";
        _bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        AdRequest adRequest = new AdRequest.Builder().Build();

        _bannerView.LoadAd(adRequest);
    }

    public void DisplayBanner()
    {
        _bannerView.Show();
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received");
        DisplayBanner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: "
              + args.Message);
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        print("HandleAdLeavingApplication event received");
    }

    private void HandleAdBannerEvents(bool subscribe)
    {
        if (subscribe)
        {
            _bannerView.OnAdLoaded += HandleOnAdLoaded;
            _bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        }
        else
        {
            _bannerView.OnAdLoaded -= HandleOnAdLoaded;
            _bannerView.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
        }
    }

    private void OnEnable()
    {
        HandleAdBannerEvents(true);
    }

    private void OnDisable()
    {
        HandleAdBannerEvents(false);
    }
}