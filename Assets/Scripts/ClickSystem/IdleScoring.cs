using System.Collections;
using System.Numerics;
using UnityEngine;

public class IdleScoring : MonoBehaviour
{
    private ScoreData scoreData;
    private void Start()
    {
        scoreData = GetComponent<ScoreData>();
        StartCoroutine(IdleScore());
    }
    private IEnumerator IdleScore()
    {
        yield return new WaitForSeconds(1);
        scoreData.CurrentScore += scoreData.IdleScore;
        StartCoroutine(IdleScore());
    }
}
