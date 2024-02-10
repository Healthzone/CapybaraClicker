using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField]
    private GameObject leaderBoardView;

    public void OpenLeaderBoardPanel()
    {
        leaderBoardView?.SetActive(true);
    }

    public void CloseLeaderboardPanel()
    {
        leaderBoardView?.SetActive(false);
    }
    public void ResetSaveProgress()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }
}
