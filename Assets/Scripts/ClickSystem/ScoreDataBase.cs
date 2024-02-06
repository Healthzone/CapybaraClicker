using UnityEngine;
public class ScoreDataBase
{
    public ulong ClickScore;
    public ulong CurrentScore;
    public ulong IdleScore;

    public ScoreDataBase()
    {
        ClickScore = 1;
        CurrentScore = 0;
        IdleScore = 1;
    }

    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
}