using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform portal2;
    [SerializeField] private Vector3 offset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.position = portal2.position + offset;
    }
}