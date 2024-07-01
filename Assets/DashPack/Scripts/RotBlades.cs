using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBlades : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    [SerializeField] private Vector3 rotDirection;
    void Update()
    {
        transform.Rotate(rotDirection, Time.deltaTime * rotSpeed);
    }
}
