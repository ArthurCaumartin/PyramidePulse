using UnityEngine;
using DG.Tweening;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 _targetPoint;
    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private float _travelDuration;
    [SerializeField] private float _timeKillTrigger;
    [SerializeField] private NoteManager _noteManager;
    [SerializeField] private AnimationCurve yFlollowingCurve;
    private float _time;

    void Update()
    {
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

    public void AnimeNoteKilled()
    {
        Vector2 startPosition = transform.position;
        DOTween.To((time) =>
        {
            startPosition.y = yFlollowingCurve.Evaluate(time);
            Vector2.Lerp(startPosition, new Vector2(startPosition.x + 1, startPosition.y), time);
        }, 0f, 1, 0.25f);
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
