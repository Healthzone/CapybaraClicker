using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class TestConnection : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TestConnectionCor());
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("IsAuth: " + SessionState.GetBool("IsAuth", false));
        }
    }

    private IEnumerator TestConnectionCor()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://localhost:7122/api/Auth/check"))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                string result = webRequest.downloadHandler.text;
                SessionState.SetBool("IsAuth", true);
                Debug.Log("IsAuth: " + SessionState.GetBool("IsAuth", false));
            }
        }
    }
}
