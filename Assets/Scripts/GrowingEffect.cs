using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrowingEffect : MonoBehaviour
{
    public Conductor conductor;
    public AnimationCurve growingCurve;
    public float growingValue;
    [Tooltip("le temps en sec pour effectuer le grossissement")]
    [Range(0,1)] public float growingTime;

    private void Start()
    {
        conductor = Conductor.instance;
        conductor.OnBoucleCompleted.AddListener(SpriteGrowingEffect);
    }

    public void SpriteGrowingEffect(float Time)
    {
        transform.DOScale(transform.localScale * growingValue, growingTime * Time / 2).SetEase(growingCurve).OnComplete(() =>
        {
            transform.DOScale(transform.localScale / growingValue, growingTime * Time / 2).SetEase(growingCurve);
        });
    }

}
