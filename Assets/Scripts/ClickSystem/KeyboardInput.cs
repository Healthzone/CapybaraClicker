using System.Text;
using TMPro;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private ScoreData scoreData;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        scoreData = GetComponent<ScoreData>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            scoreData.ScoreDataBase.CurrentScore += scoreData.ScoreDataBase.ClickScore;
            ClickerScoring.PlayerClicked?.Invoke();

            var labelTextGameObject = ClickLabelObjectPool.SharedInstance.GetPooledObject();
            if (labelTextGameObject != null)
            {
                Vector3 screenPosition = new Vector3(Screen.width / 2, Screen.height / 2, camera.nearClipPlane);

                var worldPosition = camera.ScreenToWorldPoint(screenPosition);

                labelTextGameObject.transform.position = worldPosition;
                var labelText = new StringBuilder("+").Append(IntToStringConverter.Int2String(scoreData.ScoreDataBase.ClickScore)).ToString();
                labelTextGameObject.GetComponent<TextMeshProUGUI>().SetText(labelText);
                labelTextGameObject.GetComponent<ClickLabelFade>().DoFadeLabelText();
            }
        }
    }
}

