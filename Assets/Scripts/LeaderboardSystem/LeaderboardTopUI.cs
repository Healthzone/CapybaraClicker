using Assets.ModelsDTO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardTopUI : MonoBehaviour
{
    [SerializeField]
    private LeaderboardController leaderboardController;

    [SerializeField]
    private LeaderboardItemUI[] leaderboardItemUI;

    private LeaderboardsTop leaderboardModel;

    public void OnEnable()
    {
        GetLeaderboardTop();
    }

    private async void GetLeaderboardTop()
    {
        leaderboardModel = await leaderboardController.StartGettingLeaderboardTop();
        AssignLeaderboardsData();
    }

    private void AssignLeaderboardsData()
    {
        for (int i = 0; i < leaderboardModel.Users.Count; i++)
        {
            leaderboardItemUI[i].UsernameLabel.text = leaderboardModel.Users[i].Username;
            leaderboardItemUI[i].ScoreLabel.text = leaderboardModel.Users[i].Score.ToString();
        }
    }
}
