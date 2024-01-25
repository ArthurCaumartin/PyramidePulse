using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpriteSwaper : MonoBehaviour
{
    public List<Sprite> _spriteList;
    private SpriteRenderer _spriteReder;
    bool _trailDirection;

    public Animation swipeAnim;

    void Start()
    {
        _spriteReder = GetComponent<SpriteRenderer>();
    }

    public void SwapSprite(int index)
    {
        _trailDirection = !_trailDirection;
        _spriteReder.sprite = _spriteList[index];
        if(swipeAnim)
        {
            if(_trailDirection)
                swipeAnim.Play("SwipeLeft");
            else
                swipeAnim.Play("SwipeRight");
        }
    }
}
