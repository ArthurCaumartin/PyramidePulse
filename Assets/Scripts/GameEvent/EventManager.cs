using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameEvent
{
    public bool pauseGame;
    public bool clearNotes;
    public bool goLvl2;

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
}
