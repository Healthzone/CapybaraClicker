using Assets.ModelsDTO;
using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nicknameField;

    [SerializeField]
    private TMP_InputField _passwordField;

    [SerializeField]
    private TextMeshProUGUI _validationLabel;

    [SerializeField]
    private Toggle _rememberMeToggle;

    private CapybaraData _capybaraData;

    public void Start()
    {
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
        AutoCompleteAuthData();
    }
    public async void StartLogin()
    {
        await Login();
    }
    private async UniTask Login()
    {
        var loginModel = new AuthModel()
        {
            Username = _nicknameField.text,
            Password = _passwordField.text
        };

        if (loginModel.Password == string.Empty || loginModel.Username == string.Empty)
        {
            _validationLabel.text = "Заполните все поля";
            _validationLabel.color = Color.red;
            return;
        }

        try
        {
            var request = await UnityWebRequest.Post(_capybaraData.StringConnection + "/api/Auth/login", loginModel.ToString(), "application/json")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User successful logged");
                SaveSessionState();
                LoadGame();
            }
            else
            {

            }
        }
        catch (UnityWebRequestException ex)
        {
            if (ex.ResponseCode == 400)
            {
                _validationLabel.text = "Имя пользователя или пароль неверны";
                _validationLabel.color= Color.red;
            }
            else
            {
                _validationLabel.text = "Сервер не отвечает";
                _validationLabel.color = Color.red;
            }
        }
    }   
    private void SaveSessionState()
    {
        PlayerPrefs.SetInt("IsAuth", 1);
        PlayerPrefs.SetString("AuthDuration", DateTime.Now.AddDays(1).ToString());
        PlayerPrefs.SetString("Login", _nicknameField.text);

        if (_rememberMeToggle.isOn)
        {

            PlayerPrefs.SetString("Password", _passwordField.text);
            PlayerPrefs.SetInt("IsRememberedAuthData", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("IsRememberedAuthData", 0);
            PlayerPrefs.DeleteKey("Password");
            PlayerPrefs.Save();
        }

    }
    private void AutoCompleteAuthData()
    {
        if (PlayerPrefs.GetInt("IsRememberedAuthData", 1) == 1)
        {
            _nicknameField.text = PlayerPrefs.GetString("Login", "");
            _passwordField.text = PlayerPrefs.GetString("Password", "");
            _rememberMeToggle.isOn = true;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
