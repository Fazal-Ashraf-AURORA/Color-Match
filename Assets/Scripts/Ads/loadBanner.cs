using UnityEngine;
using UnityEngine.Advertisements;

public class loadBanner : MonoBehaviour
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    BannerPosition bannerPosition = BannerPosition.TOP_CENTER;

    private void Start() {

        #if UNITY_IOS
            adUnitId = iosAdUnitId;
        #elif UNITY_ANDROID
            adUnitId = androidAdUnitId;
        #endif

        Advertisement.Banner.SetPosition(bannerPosition);
    }

    public void LoadBanner() {
        BannerLoadOptions options = new BannerLoadOptions() {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerLoadError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    public void OnBannerLoaded() {
        print("Banner Loaded!!");
        ShowBannerAd();
    }

    public void OnBannerLoadError(string error) {
        print("Banner failed to load "+ error);
    }

    public void ShowBannerAd() {
        BannerOptions options = new BannerOptions() { 
            showCallback = OnBannerShown,
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden
        };

        Advertisement.Banner.Show(adUnitId, options);
    }

    void OnBannerShown() {

    }

    void OnBannerClicked() {

    }

    void OnBannerHidden() {

    }

    public void HideBannerAd() {
        Advertisement.Banner.Hide();
    }
}
