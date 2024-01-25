using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChordController : MonoBehaviour
{
    public int index;
    public Vector2 spawnPoint;
    public List<NoteBehavior> noteBehaviours;
    public List<Vector3> startChordsPosition;
    private LineRenderer lineRenderer;

    public int limitOfPointSelected;
    public int pointIndex = 0;
    public List<int> selectedIndexForWave;
    //public float oui = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoteBehavior note = collision.GetComponent<NoteBehavior>();
        if (note)
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

    private void Awake()
    {
        spawnPoint = transform.right * -10;
        spawnPoint.y = transform.position.y;
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.Lerp(spawnPoint, transform.position, Mathf.InverseLerp(0, lineRenderer.positionCount, i)));
            startChordsPosition.Add(lineRenderer.GetPosition(i));
        }
    }

    public void ChordPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (noteBehaviours.Count > 0)
            {
                float distance = Vector3.Distance(transform.position, noteBehaviours[0].transform.position);
                //print("distance : " + distance);
                NoteManager.instance.OnInputPressed(index, noteBehaviours[0], distance);
            }
            else
            {
                NoteManager.instance.OnInputPressed(index);
            }
        }
    }
}
