using UnityEngine;
using UnityEngine.InputSystem;

public class ChordController : MonoBehaviour
{
    public int index;
    public Vector2 spawnPoint;

    private void Awake()
    {
        spawnPoint = transform.right * -10;
        spawnPoint.y = transform.position.y;
    }

    public void ChordPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            NoteManager.instance.OnInputPressed(index);
        }
    }
}
