using Assets.ModelsDTO;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class RegisterController : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField _nicknameField;

    [SerializeField]
    private TMP_InputField _passwordField;

    [SerializeField]
    private TextMeshProUGUI _validationRegisterLabel;

    [SerializeField]
    private TextMeshProUGUI _validationLoginLabel;

    private CapybaraData _capybaraData;

    public void Start()
    {
        _capybaraData = Resources.Load<CapybaraData>("CapybaraData");
    }

    public async void StartRegister()
    {
        await Register();
    }

    private async UniTask Register()
    {
        var registerModel = new AuthModel()
        {
            Username = _nicknameField.text,
            Password = _passwordField.text
        };

        if (registerModel.Password == string.Empty || registerModel.Username == string.Empty)
        {
            _validationRegisterLabel.text = "Заполните все поля";
            _validationRegisterLabel.color = Color.red;
            return;
        }

        try
        {
            var request = await UnityWebRequest.Post(_capybaraData.StringConnection + "/api/Auth/register", registerModel.ToString(), "application/json")
                .SendWebRequest()
                .WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User successful registered");
                _validationLoginLabel.text = "Вы успешно зарегистрировались";
                _validationLoginLabel.color = Color.green;

                GetComponent<MenuUI>().CloseRegisterView();
            }
            else
            {

            }
        }
        catch (UnityWebRequestException ex)
        {
            if (ex.ResponseCode == 409)
            {
                _validationRegisterLabel.text = "Пользователь с таким никнеймом уже существует";
                _validationRegisterLabel.color= Color.red;
            }
            else
            {
                _validationRegisterLabel.text = "Сервер не отвечает";
                _validationRegisterLabel.color = Color.red;
            }

        }
    }
}
