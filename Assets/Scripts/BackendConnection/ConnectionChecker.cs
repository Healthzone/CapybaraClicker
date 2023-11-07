using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject spinenrGameObject;

    [SerializeField]
    private GameObject playOfflineButton;

    [SerializeField]
    private GameObject playOnlineButton;

    [SerializeField]
    private TextMeshProUGUI serverStatusLabel;

    private CapybaraData _capybaraData;
    private async void Start()
    {
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
        await CheckConnection();
    }

    private async UniTask<string> CheckConnection()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3), ignoreTimeScale: false);
        try
        {
            var request = await UnityWebRequest.Get(_capybaraData.StringConnection + "Auth/check")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                var text = request.downloadHandler.text;
                ProcessServerOnline();
                serverStatusLabel.text = "Сервера функционируют";
                serverStatusLabel.color = Color.green;
                return text;
            }
            else
            {
                ProcessServerOffline();
                serverStatusLabel.text = "Ошибка получения статуса серверов";
                serverStatusLabel.color = Color.red;
                return "Server is having trouble";

            }

        }
        catch (UnityWebRequestException ex)
        {
            ProcessServerOffline();
            serverStatusLabel.text = "Сервера выключены";
            serverStatusLabel.color = Color.red;
            return ex.Message;
        }
    }

    private void ProcessServerOffline()
    {
        spinenrGameObject.SetActive(false);
        playOfflineButton.SetActive(true);
    }
    private void ProcessServerOnline()
    {
        spinenrGameObject.SetActive(false);
        playOnlineButton.SetActive(true);
    }
}
