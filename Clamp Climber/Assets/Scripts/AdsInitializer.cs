using UnityEngine.Advertisements;
using UnityEngine;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameID;
    [SerializeField] private string _iOSGameID;
    [SerializeField] private bool _testMode;

    private string _gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameID
            : _androidGameID;

        Advertisement.Initialize(_gameID, _testMode);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Реклама норм");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Реклама НЕ норм: {error.ToString()} - {message}");
    }
}
