using System.Numerics;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public BigInteger IdleScore;
    public BigInteger ClickScore;

    public BigInteger CurrentScore;

    private void Start()
    {
        var idleScoreString = PlayerPrefs.GetString("IdleScore", "1");
        var clickScoreString = PlayerPrefs.GetString("ClickScore", "1");
        var currentScoreString = PlayerPrefs.GetString("CurrentScore", "0");

        IdleScore = BigInteger.Parse(idleScoreString);
        ClickScore = BigInteger.Parse(clickScoreString);
        CurrentScore = BigInteger.Parse(currentScoreString);
    }
}
