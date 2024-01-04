using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyLabel : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    private ulong score;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        var uLong = new ulong();
        uLong = ulong.Parse(textMeshProUGUI.text);
        textMeshProUGUI.SetText(IntToStringConverter.Int2String(uLong));
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            score += 100;
            textMeshProUGUI.SetText(IntToStringConverter.Int2String(score));
        }
    }

    private IEnumerator TextUpdate()
    {
        score++;
        yield return new WaitForSeconds(0.2f);
    }
}
