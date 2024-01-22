using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPoint;
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private float _travelDuration;
    [SerializeField] private float _timeKillTrigger;
    private float _time;

    void Update()
    {
        _time += Time.deltaTime / _travelDuration;
        transform.position = Vector3.LerpUnclamped(_spawnPoint, _targetPoint, _time);

        if(_time >= _timeKillTrigger)
            Destroy(gameObject);
    }

    public void Initialize(Vector3 spawn, Vector3 target, float travelDuration)
    {
        _spawnPoint = spawn;
        _targetPoint = target;
        _travelDuration = travelDuration;

        transform.position = _spawnPoint;
    }
}
