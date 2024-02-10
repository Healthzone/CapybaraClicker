using UnityEngine;
using YG;

public class ScoreData : MonoBehaviour
{
    public ScoreDataBase ScoreDataBase;
    public ulong TotalScore;

    private void Awake()
    {
        ScoreDataBase = new ScoreDataBase();
        if (YandexGame.SDKEnabled)
        {
            InitScoreData();
        }
    }
    private void InitScoreData()
    {
        if (YandexGame.savesData.scoreDataJson != "")
        {
            ScoreDataBase = JsonUtility.FromJson<ScoreDataBase>(YandexGame.savesData.scoreDataJson);
        }
    }

    public void SaveScoreData()
    {
        YandexGame.savesData.scoreDataJson = ScoreDataBase.ToString();
        YandexGame.SaveProgress();
    }
}
