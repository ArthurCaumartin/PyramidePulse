using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwaper : MonoBehaviour
{
    public List<Sprite> _spriteList;
    private SpriteRenderer _spriteReder;

    void Start()
    {
        _spriteReder = GetComponent<SpriteRenderer>();
    }

    public void SwapSprite(int index)
    {
        _spriteReder.sprite = _spriteList[index];
    }
}
