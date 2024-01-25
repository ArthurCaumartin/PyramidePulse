using UnityEngine;
using UnityEngine.InputSystem;

public class InputLayerOrder : MonoBehaviour
{
    public Color baseColor;
    public Color targetColor;

    public void changeLayerOrder(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder = 51;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder = 49;
        }
    }
}
