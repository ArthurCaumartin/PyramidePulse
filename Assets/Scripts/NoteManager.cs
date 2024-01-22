using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;
    [SerializeField] private ChordController[] chordControllers;
    [SerializeField] private List<GameObject> notesList;
    [SerializeField] private GameObject notePrefab;

    private void Awake()
    {
        instance = this;
    }

    public void RemoveNoteFromList(GameObject objectToRemove)
    {
        if (notesList.Count > 0)
        {
            if(notesList.Contains(objectToRemove))
            {
                notesList.Remove(objectToRemove);
            }
        }
    }

    public void OnInputPressed(int index)
    {
        print(index);
    }

    public void SpawnNote()
    {
        int index = Random.Range(0, chordControllers.Length);
        GameObject actualObject = Instantiate(notePrefab, transform);
        actualObject.GetComponent<NoteBehavior>().Initialize(chordControllers[index].spawnPoint, chordControllers[index].transform.position, Conductor.instance.GetSecondPerBeat() * 3, this);
        notesList.Add(actualObject);
    }
}
