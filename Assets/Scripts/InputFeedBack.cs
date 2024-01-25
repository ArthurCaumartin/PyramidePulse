using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InputFeedBack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color notOnColor;
    public Color onColor;
    public Color failedColor;
    public Color targetColor;
    public GameObject mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.gameObject;
        targetColor = notOnColor;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DefaultInput()
    {
        targetColor = onColor;
        transform.DOShakePosition(.25f, .15f);
        transform.DOScale(1.25f, .15f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            targetColor = notOnColor;
        }); ;
    }

    public void FailedInput()
    {
        targetColor = failedColor;
        mainCamera.transform.DOShakePosition(.25f, .25f, 100);
        transform.DOShakePosition(.25f, 1f, 100).OnComplete(() =>
        {
            targetColor = notOnColor;
        });
    }

    private void Update()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime * 50); ;
    }
}
