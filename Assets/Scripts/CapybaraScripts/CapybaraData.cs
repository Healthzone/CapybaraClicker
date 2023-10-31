using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CapybaraData", menuName = "ScriptableObjects/CapybaraScriptableObject", order = 1)]
public class CapybaraData : ScriptableObject
{
    [Range(0f, 1f)]
    public float LowerScaleLimt = 0.2f;
    [Range(0f, 1f)]
    public float UpperScaleLimit = 0.5f;

    public float LowerYPosition = -2.45f;

    public float UpperYPosition = 0.15f;
}
