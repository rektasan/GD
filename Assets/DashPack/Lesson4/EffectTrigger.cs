using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private Color colored;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = colored;
        }
    }
}