using System.Numerics;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public BigInteger IdleScore;
    public BigInteger ClickScore;
    public BigInteger CurrentScore;
    public BigInteger MaxScore;

    public bool NeedToUpdateLeaderboard = false;

    private void Start()
    {
        var idleScoreString = PlayerPrefs.GetString("IdleScore", "1");
        var clickScoreString = PlayerPrefs.GetString("ClickScore", "1");
        var currentScoreString = PlayerPrefs.GetString("CurrentScore", "0");
        var maxScoreString = PlayerPrefs.GetString("MaxScore", "0");

        IdleScore = BigInteger.Parse(idleScoreString);
        ClickScore = BigInteger.Parse(clickScoreString);
        CurrentScore = BigInteger.Parse(currentScoreString);
        MaxScore = BigInteger.Parse(maxScoreString);
    }

    public void SaveScoreData()
    {
        PlayerPrefs.SetString("IdleScore", IdleScore.ToString());
        PlayerPrefs.SetString("ClickScore", ClickScore.ToString());
        PlayerPrefs.SetString("CurrentScore", CurrentScore.ToString());

        if (CurrentScore > MaxScore)
        {
            PlayerPrefs.SetString("MaxScore", CurrentScore.ToString());
            MaxScore = CurrentScore;
            NeedToUpdateLeaderboard = true;
        }
    }
}
