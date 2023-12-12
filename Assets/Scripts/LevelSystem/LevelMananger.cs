using System;
using UnityEngine;

public class LevelMananger : MonoBehaviour
{
    public static event Action<int> OnLevelUp;

    public int clickAmount;
    public int clicksCurrent;
    public int capybaraLevel = 1;

    [SerializeField]
    private int clickAmountBase = 300;
    [SerializeField]
    private int clickAmountMultiplier = 2;

    private void Awake()
    {
        capybaraLevel = PlayerPrefs.GetInt("CapybaraLevel", 1);
        clicksCurrent = PlayerPrefs.GetInt("ClicksCurrent", 0);
    }
    private void Start()
    {
        ClickerScoring.PlayerClicked += Click;
        CalculateClicksAmount();
    }

    private void CalculateClicksAmount()
    {
        clickAmount = capybaraLevel * (clickAmountBase * clickAmountMultiplier);
    }

    private void SaveClicksData()
    {
        PlayerPrefs.SetInt("CapybaraLevel", capybaraLevel);
        // PlayerPrefs.SetInt("ClicksCurrent", clicksCurrent);
    }

    private void Click()
    {
        clicksCurrent++;
        if (clicksCurrent >= clickAmount)
        {
            capybaraLevel++;
            CalculateClicksAmount();
            SaveClicksData();
            clicksCurrent = 0;
            OnLevelUp?.Invoke(capybaraLevel);
        }
    }
}
