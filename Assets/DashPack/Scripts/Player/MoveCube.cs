using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [SerializeField] private float gravity = -25;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 10;
    [SerializeField] private float rotSpeed = 125f;

    [SerializeField] private ParticleSystem trailParticles;

    [SerializeField] private Transform playerModel;

    [SerializeField] private LayerMask mask;

    [SerializeField] private Vector3 boxOffset = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector2 boxSize = new Vector2(0.8f, 0.05f);

    private bool isGrounded = true;
    private Rigidbody2D rgb;

    void Start()
    {
        Physics2D.gravity = new Vector2(0, gravity);
        rgb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(transform.position - transform.localScale.x * boxOffset, transform.localScale.x * boxSize, 0f, mask);

        if(isGrounded)
        {
            trailParticles.Play();

            Vector3 rot = playerModel.rotation.eulerAngles;
            rot.z = Mathf.Round(rot.z / 90) * 90;
            playerModel.rotation = Quaternion.Euler(rot);

            if (Input.GetKey(KeyCode.Space))
            {
                rgb.velocity = Vector2.zero;
                rgb.AddForce(Vector2.up * jump * transform.localScale.x, ForceMode2D.Impulse);
            }
        }
        else
        {
            playerModel.Rotate(Vector3.back, rotSpeed / transform.localScale.x * Time.deltaTime);

            trailParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.localScale.x * boxOffset, transform.localScale.x * boxSize);
    }
}