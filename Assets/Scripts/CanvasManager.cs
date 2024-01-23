using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    [Header("Affection Ref :")]
    [SerializeField] private Image _affectionFillImage;

    void Awake()
    {
        instance = this;
    }

    public void SetAffectionFill(float value)
    {
        _affectionFillImage.fillAmount = value;
    }
}
