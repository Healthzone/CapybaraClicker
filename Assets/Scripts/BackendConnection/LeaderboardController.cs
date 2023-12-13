using Cysharp.Threading.Tasks;
using TMPro;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System;
using Assets.ModelsDTO;

public class LeaderboardController : MonoBehaviour
{
    private CapybaraData _capybaraData;

    [SerializeField]
    private TMP_InputField _label;

    void Start()
    {
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
    }

    public async void StartGettingLeaderboardTop()
    {
        await GetLeaderboardTop();
    }

    public async void StartSettingLeaderboardValue()
    {
        await SetLeaderboardTopValue();
    }

    private async UniTask SetLeaderboardTopValue()
    {
        var leaderboardModel = new LeaderboardModel()
        {
            Username = PlayerPrefs.GetString("Login", ""),
            Score = long.Parse(_label.text)
        };
        try
        {
            var request = await UnityWebRequest.Post(_capybaraData.StringConnection + "/api/Home/addResult", leaderboardModel.ToString(), "application/json")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(request.downloadHandler.text);
            }
            else
            {

            }
        }
        catch (UnityWebRequestException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private async UniTask GetLeaderboardTop()
    {
        try
        {
            var request = await UnityWebRequest.Get(_capybaraData.StringConnection + "/api/Home/getTopPlayers")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(request.downloadHandler.text);
            }
            else
            {

            }
        }
        catch (UnityWebRequestException ex)
        {
            Debug.Log(ex.Message);
        }
    }
}
