using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "4664671";
    [SerializeField] string _iOSGameId =  "4664670";
    [SerializeField] bool _testMode = true;
    private string _gameId;


    public bool initialized = false;

    void Start()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
      /* _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;*/
        
#if UNITY_IOS
        string _gameId = _iOSGameId;
#elif UNITY_ANDROID
        string _gameId = _androidGameId;
#endif
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        initialized = true;
        Debug.Log("Unity Ads initialization complete.");
        GetComponent<RewardedAds>().LoadAd();
        GetComponent<InterstitialAd>().LoadAd();
        GetComponent<BannerAd>().LoadBanner();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        FindObjectOfType<GameFunctions>().canContinue = false;
        initialized = false;
        //FindObjectOfType<GameFunctions>().ShowAdError($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        FindObjectOfType<GameFunctions>().ShowAdError("Connect Network");
    }
}