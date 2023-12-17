using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardSaver : MonoBehaviour
{
    [SerializeField]
    private int saveDelay;

    [SerializeField]
    private LeaderboardController controller;

    [SerializeField]
    private ScoreData scoreData;

    private void Start()
    {
        StartCoroutine(TrySaveUserScoreInLeaderboard());
    }

    private IEnumerator TrySaveUserScoreInLeaderboard()
    {
        yield return new WaitForSeconds(saveDelay);
        if (scoreData.NeedToUpdateLeaderboard)
        {
            controller.StartSettingLeaderboardValue();
            scoreData.NeedToUpdateLeaderboard = false;
        }
        StartCoroutine(TrySaveUserScoreInLeaderboard());
    }
}
