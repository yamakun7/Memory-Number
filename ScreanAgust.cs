using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreanAgust : MonoBehaviour
{
    void Start()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 scale = max * 2;
        transform.localScale = scale;
    }
}
