using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
