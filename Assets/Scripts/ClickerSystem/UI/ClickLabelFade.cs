using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ClickLabelFade : MonoBehaviour
{
    public void DoFadeLabelText()
    {
        var textMeshPro = GetComponent<TextMeshProUGUI>();

        gameObject.SetActive(true);
        DoFadeAsync(textMeshPro);
    }

    private async void DoFadeAsync(TextMeshProUGUI textMeshProUGUI)
    {
        var ct = textMeshProUGUI.GetCancellationTokenOnDestroy();
        await UniTask.WhenAll(
        textMeshProUGUI.DOFade(0f, 1.5f).WithCancellation(ct),
        textMeshProUGUI.transform.DOMoveY(transform.position.y + 2f, 1.5f).WithCancellation(ct));

        gameObject.SetActive(false);
        textMeshProUGUI.color = Color.white;
        transform.position = Vector3.zero;
    }
}
