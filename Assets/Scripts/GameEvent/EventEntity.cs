using System;
using UnityEngine;

public class EventEntity : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _animator.SetBool("Play", true);
    }
    
    public void Reset()
    {
        _animator.speed = 0;
    }
}
