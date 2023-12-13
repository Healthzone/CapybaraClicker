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
        levelMananger = GetComponent<LevelMananger>();
        StartCoroutine(UpdateUIAtFirst());
    }
    IEnumerator UpdateUIAtFirst()
    {
        yield return new WaitForEndOfFrame();
        UpdateClickUI();
    }

    public void UpdateClickUI()
    {
        var value = (float)levelMananger.clicksCurrent / levelMananger.clickAmount;
        levelSlider.value = value == 1f ? 0 : value;
        levelLabel.text = levelMananger.capybaraLevel.ToString();
    }
}
