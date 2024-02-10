using System.Collections;
using UnityEngine;
using YG;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private AdsWindowUI adsWindowGameObject;

    private void Update()
    {
        if (YandexGame.timerShowAd >= YandexGame.Instance.infoYG.fullscreenAdInterval)
        {
            adsWindowGameObject.gameObject.SetActive(true);
        }
    }
}
