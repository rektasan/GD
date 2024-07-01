using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePortal : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float newSize = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.localScale = Vector3.one * newSize;
    }
}