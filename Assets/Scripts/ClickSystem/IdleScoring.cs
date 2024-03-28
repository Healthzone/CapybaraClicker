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
        scoreData.ScoreDataBase.CurrentScore += scoreData.ScoreDataBase.IdleScore;
        scoreData.TotalScore += scoreData.ScoreDataBase.IdleScore;
        ShopSystem.OnUINeedUpdated?.Invoke();
        StartCoroutine(IdleScore());
    }
}
