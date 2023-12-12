using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    private Slider levelSlider;
    [SerializeField]
    private TextMeshProUGUI levelLabel;

    private LevelMananger levelMananger;

    private void Awake()
    {
        ClickerScoring.PlayerClicked += UpdateClickUI;
        levelMananger = GetComponent<LevelMananger>();
        StartCoroutine(UpdateUIAtFirst());
    }
    IEnumerator UpdateUIAtFirst()
    {
        yield return new WaitForEndOfFrame();
        UpdateClickUI();
    }

    private void UpdateClickUI()
    {
        levelSlider.value = (float)levelMananger.clicksCurrent / levelMananger.clickAmount;
        levelLabel.text = levelMananger.capybaraLevel.ToString();
    }
}
