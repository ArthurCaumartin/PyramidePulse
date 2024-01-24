using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameEvent
{
    public float eventDuration;
    public bool pauseGame;

    //TODO Anim + fct dans noteManager
    public bool clearNotes;

    //TODO Feed back : glow sur les chordes
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
        if(value.pauseGame)
            StartCoroutine(GamePause(value.eventDuration));

        if(value.canPlayerSpam)
            StartCoroutine(PlayerSpam(value.eventDuration));
    }

    IEnumerator PlayerSpam(float time)
    {
        GameManager.instance.canPlayerSpam = true;
        yield return new WaitForSeconds(time);
        GameManager.instance.canPlayerSpam = false;
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
