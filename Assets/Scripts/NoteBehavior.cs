using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField] private Vector2 _targetPoint;
    [SerializeField] private Vector2 _spawnPoint;
    [SerializeField] private float _travelDuration;
    [SerializeField] private float _timeKillTrigger;
    [SerializeField] private NoteManager _noteManager;
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
                //_noteManager.RemoveNoteFromList(this.gameObject);
                Destroy(this.gameObject);
            }
        }
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
