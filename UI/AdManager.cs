using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public string _gameID = "3199808";
    public bool _testMode = true;
    public string _bannerAd = "Banner";
    private string _videoAd = "video";

    private void Start()
    {
        Debug.Log("Started");
        Advertisement.Initialize(_gameID, _testMode);
        StartCoroutine(ShowBannerWhenReady());
        Debug.Log("Finished");
    }

    private IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(_bannerAd))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Show(_bannerAd);
    }
    public enum BannerPosition 
    {
        TOP_LEFT,
        TOP_CENTER,
        TOP_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_CENTER,
        BOTTOM_RIGHT,
        CENTER
    }
}