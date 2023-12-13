using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject LoginViewGameObject;

    [SerializeField]
    private GameObject RegisterViewGameObejct;

    [SerializeField]
    private GameObject TitleViewGameObject;

    [SerializeField]
    private GameObject ServerConnectionViewGameObject;

    [SerializeField]
    private GameObject TestViewGameObject;

    [SerializeField]
    private TMP_InputField testIpField;

    public void SkipTitle()
    {
        if (TitleViewGameObject != null && ServerConnectionViewGameObject != null)
        {
            TitleViewGameObject.SetActive(false);
            TestViewGameObject.SetActive(true);
        }
    }
    public void OpenLoginView()
    {
        CheckIsUserLogged();

        if (ServerConnectionViewGameObject != null && LoginViewGameObject != null)
        {
            ServerConnectionViewGameObject.SetActive(false);
            LoginViewGameObject.SetActive(true);
        }
    }

    public void CloseTestWindow()
    {
        var tmp = testIpField.text;
        if (tmp != string.Empty)
            PlayerPrefs.SetString("IP", testIpField.text);
        if (ServerConnectionViewGameObject != null && TestViewGameObject != null)
        {
            TestViewGameObject.SetActive(false);
            ServerConnectionViewGameObject.SetActive(true);
        }
    }

    private void CheckIsUserLogged()
    {
        if (PlayerPrefs.GetInt("IsAuth", 0) == 1)
        {
            var datetime = DateTime.Parse(PlayerPrefs.GetString("AuthDuration", DateTime.MinValue.ToString()));

            if (datetime >= DateTime.Now)
                SceneManager.LoadScene("GameScene");
        }
    }

    public void OpenRegisterView()
    {
        if (LoginViewGameObject != null && RegisterViewGameObejct != null)
        {
            LoginViewGameObject.SetActive(false);
            RegisterViewGameObejct.SetActive(true);
        }
    }

    public void CloseRegisterView()
    {
        if (LoginViewGameObject != null && RegisterViewGameObejct != null)
        {
            RegisterViewGameObejct.SetActive(false);
            LoginViewGameObject.SetActive(true);
        }
    }
}
