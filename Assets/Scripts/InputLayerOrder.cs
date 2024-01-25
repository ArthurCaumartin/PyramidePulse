using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InputLayerOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color notOnColor;
    public Color onColor;
    public Color failedColor;
    public Color targetColor;

    private void Awake()
    {
        targetColor = notOnColor;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void changeLayerOrder(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            targetColor = onColor;
        }
        else
        {
            targetColor = notOnColor;
        }
    }

    public void DefaultInput()
    {
        transform.DOShakePosition(.25f, .15f);
        transform.DOScale(1.25f, .15f).SetLoops(2, LoopType.Yoyo);
    }

    public void FailedInput()
    {
        targetColor = failedColor;
        transform.DOShakePosition(.25f, 1f, 100);
    }

    private void Update()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.Lerp(spriteRenderer.color, targetColor, Time.deltaTime * 50); ;
    }
}
