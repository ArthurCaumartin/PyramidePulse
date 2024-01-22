using UnityEngine;
using UnityEngine.InputSystem;

public class ChordController : MonoBehaviour
{
    public int index;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private GameObject objectToSpawn;

    private void Awake()
    {
        spawnPoint = transform.position;
        spawnPoint = new Vector2(transform.position.x - 10, transform.position.y);

        GameObject actualObject = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
    }

    public void ChordPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            print("chordPressed" + index);
        }
    }
}
