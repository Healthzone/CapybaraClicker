using System;
using UnityEngine;

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

    private LevelUI levelUI;

    private void Awake()
    {
        capybaraLevel = PlayerPrefs.GetInt("CapybaraLevel", 1);
        clicksCurrent = PlayerPrefs.GetInt("ClicksCurrent", 0);
    }
    private void Start()
    {
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
        PlayerPrefs.SetInt("CapybaraLevel", capybaraLevel);
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
