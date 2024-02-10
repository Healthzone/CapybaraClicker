using System.Collections;
using UnityEngine;

public class UserScoreSaver : MonoBehaviour
{
    [SerializeField]
    private int saveDelay;

    [SerializeField]
    private ScoreData scoreData;

    void Start()
    {
        StartCoroutine(SaveUserScore());
    }

    private IEnumerator SaveUserScore()
    {
        yield return new WaitForSeconds(saveDelay);
        scoreData.SaveScoreData();
        StartCoroutine(SaveUserScore());
    }
}
