using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNoteAnimation : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    Vector2 startPosition;
    RectTransform rect;

    void Start()
    {
        rect = (RectTransform)transform;

        startPosition = rect.anchoredPosition;
        xOffset = Random.Range(-20f, 20f);
        yOffset = Random.Range(-20f, 20f);
    }

    void Update()
    {
        rect.anchoredPosition = new Vector2(startPosition.x + (xOffset * Mathf.Cos(Time.time))
                                       , startPosition.y + (yOffset * Mathf.Sin(Time.time)));
    }
}
