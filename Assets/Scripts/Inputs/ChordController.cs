using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChordController : MonoBehaviour
{
    public int index;
    public Vector2 spawnPoint;
    public List<NoteBehavior> noteBehaviours;
    public Transform Point; //à virer
    public float distance;//à virer

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoteBehavior note = collision.GetComponent<NoteBehavior>();
        if(note)
        {
            noteBehaviours.Add(note);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NoteBehavior note = collision.GetComponent<NoteBehavior>();
        if (note && noteBehaviours.Contains(note))
        {
            noteBehaviours.Remove(note);
        }
    }
    private void OnDrawGizmos()//à virer
    {
        Gizmos.color = Color.red;//à virer
        Gizmos.DrawLine(transform.position, Point.position);//à virer
        Handles.Label(transform.position, Vector2.Distance(transform.position, Point.position).ToString());//à virer
        //à virer
    }//à virer

    private void Awake()
    {
        spawnPoint = transform.right * -10;
        spawnPoint.y = transform.position.y;
    }

    public void ChordPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(noteBehaviours.Count > 0)
            {
                NoteManager.instance.OnInputPressed(index, noteBehaviours[0]);
            }
            else
            {
                NoteManager.instance.OnInputPressed(index);
            }
        }
    }
}
