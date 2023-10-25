using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapybaraRotation : MonoBehaviour
{
    public void Start()
    {
        Sequence sequence = DOTween.Sequence();

        Vector3 vector = new Vector3(0, 0, 4f);
        Vector3 vector2 = new Vector3(0, 0, -4);
        sequence
            .Append(transform.DORotate(vector2, 1f))
            .Append(transform.DORotate(vector, 1f))
            //.Append(transform.DOShakeScale(2f, 0.5f, 2, 30, true, ShakeRandomnessMode.Harmonic))
            .SetLoops(-1, LoopType.Incremental);

    }
}
