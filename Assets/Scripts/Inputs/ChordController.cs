using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChordController : MonoBehaviour
{
    public int index;
    public Vector2 spawnPoint;
    public List<NoteBehavior> noteBehaviours;
    public Transform Point; //� virer
    public float distance;//� virer

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

    private void OnDrawGizmos()//� virer
    {
        if(!Point)
            return;
        Gizmos.color = Color.red;//� virer
        Gizmos.DrawLine(transform.position, Point.position);//� virer
        Handles.Label(transform.position, Vector2.Distance(transform.position, Point.position).ToString());//� virer
        //� virer
    }//� virer

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
