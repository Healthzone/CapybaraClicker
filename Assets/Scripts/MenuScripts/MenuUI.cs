using System;
using System.Collections;
using System.Collections.Generic;
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

    public void SkipTitle()
    {
        if (TitleViewGameObject != null && ServerConnectionViewGameObject != null)
        {
            TitleViewGameObject.SetActive(false);
            ServerConnectionViewGameObject.SetActive(true);
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
