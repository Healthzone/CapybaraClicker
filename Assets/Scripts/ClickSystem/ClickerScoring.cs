using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerScoring : MonoBehaviour
{
    public static event Action PlayerClicked; 

    [SerializeField]
    private Camera mainCamera;

    private ScoreData scoreData;

    private void Start()
    {
        scoreData = GetComponent<ScoreData>();
    }
    public void Click(BaseEventData data)
    {
        scoreData.CurrentScore += scoreData.ClickScore;
        PlayerClicked?.Invoke();

        var labelTextGameObject = ClickLabelObjectPool.SharedInstance.GetPooledObject();
        if(labelTextGameObject != null )
        {
            var pointerEventData = (PointerEventData)data;
            Vector3 screenPosition = new Vector3(pointerEventData.position.x,
                pointerEventData.position.y, mainCamera.nearClipPlane);

            var worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);

            labelTextGameObject.transform.position = worldPosition;
            var labelText = new StringBuilder("+").Append(IntToStringConverter.Int2String(scoreData.ClickScore)).ToString();
            labelTextGameObject.GetComponent<TextMeshProUGUI>().SetText(labelText);
            labelTextGameObject.GetComponent<ClickLabelFade>().DoFadeLabelText();
        }
    }
}
