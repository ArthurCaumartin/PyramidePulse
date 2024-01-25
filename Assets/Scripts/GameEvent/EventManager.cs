using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameEvent
{
    public float eventDuration;
    public bool pauseGame;
    public bool isAlreadyCalled;
    public bool clearNotes;
    public bool canPlayerSpam;
    public bool passLvl2;

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
        print("Queen Event");
        if(_queenEvent.isAlreadyCalled)
        {
            return;
        }

        _queenEvent.isAlreadyCalled = true;
        DoEventShit(_queenEvent);
        for (int i = 0; i < _queenEvent.entityList.Count; i++)
        {
            _queenEvent.entityList[i].PlayAnimation();
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
        NoteManager.instance.KillAllNotes();
    }

    void DoEventShit(GameEvent value)
    {
        if(value.pauseGame)
            StartCoroutine(GamePause(value.eventDuration));

        if(value.canPlayerSpam)
            StartCoroutine(PlayerSpam(value.eventDuration));

        if(value.passLvl2)
            StartCoroutine(StartNextLevel(value.eventDuration));
    }

    IEnumerator StartNextLevel(float time)
    {
        yield return new WaitForSeconds(time);
        Conductor.instance.Initialize(2);
    }

    IEnumerator PlayerSpam(float time)
    {
        GameManager.instance.canPlayerSpam = true;
        yield return new WaitForSeconds(time);
        GameManager.instance.canPlayerSpam = false;
    }

    IEnumerator GamePause(float time)
    {
        print("Pause Game !");
        NoteManager.instance.PauseNotes();
        Conductor.instance.Pause(true);
        yield return new WaitForSeconds(time);
        NoteManager.instance.UnpauseNotes();
        Conductor.instance.Pause(false);
        print("Unpause Game !");
    }
}
