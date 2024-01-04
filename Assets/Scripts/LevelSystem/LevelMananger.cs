using System;
using System.Collections;
using UnityEngine;
using YG;

public class LevelMananger : MonoBehaviour
{
    public static event Action<int> OnLevelUp;

    public int clickAmount;
    public int clicksCurrent;
    public int capybaraLevel = 1;

    [SerializeField]
    private float clickAmountBase = 300;
    [SerializeField]
    private float clickAmountMultiplier = 2;

    [SerializeField]
    private float timeDelay;

    private LevelUI levelUI;


    private void OnEnable() => YandexGame.GetDataEvent += InitLevelData;

    private void OnDisable() => YandexGame.GetDataEvent -= InitLevelData;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            InitLevelData();
        }
        StartCoroutine(SaveCurrentClicksAmount());
    }

    private IEnumerator SaveCurrentClicksAmount()
    {
        yield return new WaitForSeconds(timeDelay);
        if (YandexGame.SDKEnabled)
        {
            YandexGame.savesData.clicksCurrent = clicksCurrent;
            YandexGame.SaveProgress();
        }
        StartCoroutine(SaveCurrentClicksAmount());

    }

    private void InitLevelData()
    {
        capybaraLevel = YandexGame.savesData.capybaraLevel;
        clicksCurrent = YandexGame.savesData.clicksCurrent;

        levelUI = GetComponent<LevelUI>();
        ClickerScoring.PlayerClicked += Click;
        CalculateClicksAmount();
    }

    private void CalculateClicksAmount()
    {
        clickAmount = capybaraLevel * (int)(clickAmountBase * clickAmountMultiplier);
    }

    private void SaveClicksData()
    {
        YandexGame.savesData.capybaraLevel = capybaraLevel;
        YandexGame.SaveProgress();
        //PlayerPrefs.SetInt("CapybaraLevel", capybaraLevel);
        // PlayerPrefs.SetInt("ClicksCurrent", clicksCurrent);
    }

    private void Click()
    {
        clicksCurrent++;
        levelUI.UpdateClickUI();
        if (clicksCurrent >= clickAmount)
        {
            capybaraLevel++;
            levelUI.UpdateClickUI();
            CalculateClicksAmount();
            SaveClicksData();
            clicksCurrent = 0;
            OnLevelUp?.Invoke(capybaraLevel);
        }
    }
}
