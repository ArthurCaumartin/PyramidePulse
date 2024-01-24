using UnityEngine;
using DG.Tweening;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 _targetPoint;
    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private float _travelDuration;
    [SerializeField] private float _timeKillTrigger;
    [SerializeField] private NoteManager _noteManager;
    private float _time;
    public bool isPaused = false;

    void Update()
    {
        if (isPaused)
            return;

        if (_travelDuration <= 0)
        {
            return;
        }
        else
        {
            _time += Time.deltaTime / _travelDuration;
            transform.position = Vector2.LerpUnclamped(_spawnPoint, _targetPoint, _time);

            if (_time >= _timeKillTrigger)
            {
                _noteManager.RemoveNoteFromList(this.gameObject, true);

                Destroy(this.gameObject);
            }
        }
    }

    public void KillNote()
    {
        isPaused = true;
        float xOffset = Random.Range(1, 3);
        float yOffset = Random.Range(1, 3);
        transform.DOMove(new Vector2(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset), .25f)
            .OnComplete(() =>
            {
                transform.DOMove(new Vector2(transform.localPosition.x + xOffset / 3, transform.localPosition.y - yOffset * 20), .50f)
                .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
    }

    private void OnDestroy()
    {
        _noteManager.RemoveNoteFromList(this.gameObject);
    }

    public void Initialize(Vector2 spawn, Vector2 target, float travelDuration, NoteManager noteManager)
    {
        _spawnPoint = spawn;
        _targetPoint = target;
        _travelDuration = travelDuration;

        transform.position = _spawnPoint;
        _noteManager = noteManager;
    }
}
