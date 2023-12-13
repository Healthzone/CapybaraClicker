using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class IdleScoreUILabel : MonoBehaviour
{
    [SerializeField] private float period = 1f;
    private float nextActionTime = 0.0f;

    [SerializeField]
    private ScoreData scoreData;

    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

 
    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            textMeshProUGUI.SetText(IntToStringConverter.Int2String(scoreData.IdleScore));

        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            scoreData.IdleScore += 25;
        }
    }
}
