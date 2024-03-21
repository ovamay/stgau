using TMPro;
using UnityEngine;

public class ADS : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float timePopupRewardVideo = 2;
    [SerializeField] private float durationADS = 1;

    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject adsPanel;
    [SerializeField] private GameObject powerTimer;
    [SerializeField] private GameObject adsBan;

    private Yandex _yandex = new Yandex();
    private TextMeshProUGUI _powerText;

    private float _nextTimePopupRewardVideo;
    private float _nextDurationADS;
    private bool _isADSRewarded;

    private void Start()
    {
        _yandex.ShowAdv();
        _nextTimePopupRewardVideo = timePopupRewardVideo * 60;
        _nextDurationADS = durationADS * 60;
        //_powerText = powerTimer.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        //if (Time.unscaledTime > _nextDurationADS && _isADSRewarded)
        //{
        //    _isADSRewarded = false;
        //    player.IsDoubleDamage = false;
        //    powerTimer.SetActive(false);
        //}
        //else
        //    _powerText.text = $"{Mathf.Round(_nextDurationADS - Time.unscaledTime)} c";

        //if (Time.unscaledTime > _nextTimePopupRewardVideo)
        //    adsPanel.SetActive(true);
    }

    public void PlayVideoAds()
    {
        adsBan.SetActive(true);
        _yandex.ShowVideo();
        GameManager.Instance.PauseManager.Pause(true);
        AudioListener.pause = true;
    }

    public void VideoViewed()
    {
        adsBan.SetActive(false);
        AudioListener.pause = false;
        adsPanel.SetActive(false);
        _nextTimePopupRewardVideo = Time.unscaledTime + timePopupRewardVideo * 60;
        _isADSRewarded = true;
        //player.IsDoubleDamage = true;
        _nextDurationADS = Time.unscaledTime + durationADS * 60;
        powerTimer.SetActive(true);
    }

    public void ShowFullScreen()
    {
        AudioListener.pause = true;
    }

    public void FullScreenClosed()
    {
        AudioListener.pause = false;
    }
}
