using System;
using TMPro;
using UnityEngine;
using YG;

public class AdsWindowUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI adsDelayLabel;
    
    private bool isTimerStarted = false;

    private float adsDelay = 4f;

    private void OnEnable()
    {
        YandexGame.CloseFullAdEvent += CloseAdWindow;
        YandexGame.ErrorFullAdEvent += CloseAdWindow;
        isTimerStarted = true;
    }

    private void OnDisable()
    {
        YandexGame.CloseFullAdEvent -= CloseAdWindow;
        YandexGame.ErrorFullAdEvent -= CloseAdWindow;
    }

    private void CloseAdWindow()
    {
        isTimerStarted = false;
        adsDelay = 4f;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isTimerStarted)
        {
            adsDelay -= Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(adsDelay);
            adsDelayLabel.text = "Реклама начнется через " + timeSpan.ToString(@"ss");
            if(adsDelay <= 0)
            {
                YandexGame.FullscreenShow();
                isTimerStarted = false;
                adsDelay = 4f;
            }
        }
    }
}
