using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrowingEffect : MonoBehaviour
{
    public Conductor conductor;
    public float growingValue;
    [Tooltip("le temps en sec pour effectuer le grossissement")]
    public float growingTime;

    private void Start()
    {
        conductor = Conductor.instance;
        conductor.OnBoucleCompleted.AddListener(SpriteGrowingEffect);
    }

    public void SpriteGrowingEffect(float Time)
    {
        transform.DOScale(transform.localScale * growingValue, growingTime).SetLoops(2, LoopType.Yoyo);
    }

}
