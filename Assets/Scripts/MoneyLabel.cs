using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Numerics;

public class MoneyLabel : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private long score;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        var bigInteger = new BigInteger();
        bigInteger = BigInteger.Parse(textMeshProUGUI.text);
        textMeshProUGUI.SetText(IntToStringConverter.Int2String(bigInteger));
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            score+=100;
            var bigInteger = new BigInteger(score);
            textMeshProUGUI.SetText(IntToStringConverter.Int2String(bigInteger));
        }
    }

    private IEnumerator TextUpdate()
    {
        score++;
        yield return new WaitForSeconds(0.2f);
    }
}
