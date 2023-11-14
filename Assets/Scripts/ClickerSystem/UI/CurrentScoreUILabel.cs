using TMPro;
using UnityEngine;

public class CurrentScoreUILabel : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;

    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField] private float period = 1f;
    private float nextActionTime = 0.0f;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.SetText(IntToStringConverter.Int2String(scoreData.CurrentScore));
    }

    private void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            textMeshProUGUI.SetText(IntToStringConverter.Int2String(scoreData.CurrentScore));
        }
    }
}
