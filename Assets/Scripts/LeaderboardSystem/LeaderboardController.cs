using Cysharp.Threading.Tasks;
using TMPro;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Assets.ModelsDTO;
using System.Collections.Generic;

public class LeaderboardController : MonoBehaviour
{
    private CapybaraData _capybaraData;

    [SerializeField]
    private ScoreData scoreData;

    void Start()
    {
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
    }

    public async UniTask<LeaderboardsTop> StartGettingLeaderboardTop()
    {
        return await GetLeaderboardTop();
    }

    public async void StartSettingLeaderboardValue()
    {
        await SetLeaderboardTopValue();
    }

    private async UniTask<bool> SetLeaderboardTopValue()
    {
        var leaderboardModel = new User(PlayerPrefs.GetString("Login", ""), (long)scoreData.CurrentScore);

        try
        {
            var request = await UnityWebRequest.Post(_capybaraData.StringConnection + "/api/Home/addResult", leaderboardModel.ToString(), "application/json")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(request.downloadHandler.text);
                return true;
            }
            else
            {

            }
            return false;
        }
        catch (UnityWebRequestException ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
    }

    private async UniTask<LeaderboardsTop> GetLeaderboardTop()
    {
        try
        {
            var request = await UnityWebRequest.Get(_capybaraData.StringConnection + "/api/Home/getTopPlayers")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                return JsonUtility.FromJson<LeaderboardsTop>(request.downloadHandler.text);
            }
            else
            {

            }
        }
        catch (UnityWebRequestException ex)
        {
            Debug.Log(ex.Message);
        }
        return null;
    }
}
