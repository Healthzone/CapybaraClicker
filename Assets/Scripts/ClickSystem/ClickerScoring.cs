using Assets.Scripts.ShopSystem;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerScoring : MonoBehaviour
{
    public static Action PlayerClicked;

    [SerializeField]
    private Camera mainCamera;

    private ScoreData scoreData;

    private void Start()
    {
        scoreData = GetComponent<ScoreData>();
    }
    public void Click(BaseEventData data)
    {
        ProcessClick(data);
    }

    private void ProcessClick(BaseEventData data)
    {
        scoreData.ScoreDataBase.CurrentScore += scoreData.ScoreDataBase.ClickScore;
        scoreData.TotalScore += scoreData.ScoreDataBase.ClickScore;
        PlayerClicked?.Invoke();

        var labelTextGameObject = ClickLabelObjectPool.SharedInstance.GetPooledObject();
        if (labelTextGameObject != null)
        {
            var pointerEventData = (PointerEventData)data;
            Vector3 screenPosition = new Vector3(pointerEventData.position.x,
                pointerEventData.position.y, mainCamera.nearClipPlane);

            var worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

            labelTextGameObject.transform.position = worldPosition;
            var labelText = new StringBuilder("+").Append(IntToStringConverter.Int2String(scoreData.ScoreDataBase.ClickScore)).ToString();
            labelTextGameObject.GetComponent<TextMeshProUGUI>().SetText(labelText);
            labelTextGameObject.GetComponent<ClickLabelFade>().DoFadeLabelText();
        }
    }
}
