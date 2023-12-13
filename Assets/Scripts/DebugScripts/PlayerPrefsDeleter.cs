using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDeleter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("PlayerPrefs deleted");
        }
    }
}
