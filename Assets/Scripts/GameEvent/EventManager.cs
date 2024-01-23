using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameEvent
{
    public float pauseGame = 0;
    public bool clearNotes;
    public bool canPlayerSpam;

    public List<EventEntity> entityList;
}

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameEvent _queenEvent;
    [SerializeField] private GameEvent _quardEvent;
    [SerializeField] private GameEvent _kingSlamEvent;

    [ContextMenu("PlayQueenEvent")]
    public void PlayQueenEvent()
    {
        for (int i = 0; i < _queenEvent.entityList.Count; i++)
        {
            _queenEvent.entityList[i].PlayAnimation();
            DoEventShit(_queenEvent);
        }
    }

    [ContextMenu("GuardFallEvent")]
    public void GuardFallEvent()
    {
        for (int i = 0; i < _quardEvent.entityList.Count; i++)
        {
            _quardEvent.entityList[i].PlayAnimation();
        }
    }

    [ContextMenu("KingSmashEvent")]
    public void KingSmashEvent()
    {
        for (int i = 0; i < _quardEvent.entityList.Count; i++)
        {
            _quardEvent.entityList[i].PlayAnimation();
        }
    }

    void DoEventShit(GameEvent value)
    {
        if(value.pauseGame != 0)
        {
            StartCoroutine(GamePause(value.pauseGame));
        }
    }

    IEnumerator GamePause(float time)
    {
        NoteManager.instance.PauseNotes();
        Conductor.instance.Pause(true);
        yield return new WaitForSeconds(time);
        NoteManager.instance.UnpauseNotes();
        Conductor.instance.Pause(false);
    }
}
