using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;
    public List<GameObject> notesList;
    [SerializeField] private ChordController[] chordControllers;
    [SerializeField] private GameObject notePrefab;

    private void Awake()
    {
        instance = this;
    }

    public void RemoveNoteFromList(GameObject objectToRemove, bool isSeflDestroy = false)
    {
        if (notesList.Count > 0)
        {
            notesList.Remove(objectToRemove);
        }

        if(isSeflDestroy)
            GameManager.instance.DeacreaseKingAffection();
    }

    public void OnInputPressed(int index, NoteBehavior note = null, float distance = 1000)
    {
        if(note == null)
        {
            GameManager.instance.DeacreaseKingAffection();
            print("pas de note");
        }
        else
        {
            GameManager.instance.IncreaseKingAffection();
            GameManager.instance.AddScore(distance);
            Destroy(note.gameObject);
            // print(index);
        }
    }

    public void SpawnNote()
    {
        int index = Random.Range(0, chordControllers.Length);
        GameObject actualObject = Instantiate(notePrefab, transform);
        actualObject.GetComponent<NoteBehavior>().Initialize(chordControllers[index].spawnPoint, chordControllers[index].transform.position, Conductor.instance.GetSecondPerBeat(), this);
        notesList.Add(actualObject);
    }
}
