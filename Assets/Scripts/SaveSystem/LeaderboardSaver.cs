using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LeaderboardSaver : MonoBehaviour
{
    [SerializeField]
    private int saveDelay;

    [SerializeField]
    private ScoreData scoreData;

    private void Start()
    {
        StartCoroutine(SaveTotalEarnedScore());
    }

    private IEnumerator SaveTotalEarnedScore()
    {
        yield return new WaitForSeconds(saveDelay);
        YandexGame.savesData.totalEarnedScore = scoreData.TotalScore;
        YandexGame.SaveProgress();
        StartCoroutine(SaveTotalEarnedScore());
    }
}
