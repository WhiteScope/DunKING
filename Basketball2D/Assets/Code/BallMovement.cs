using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool impulsRight;
    private bool impulsLeft = true;

    private AudioSource bounce;

    private void Start()
    {
        bounce = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1.5f, 0.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (impulsLeft && !impulsRight)
            {
                impulsLeft = false;
                impulsRight = true;
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(2.5f, 5), ForceMode2D.Impulse);
                bounce.Play();
            }
            else if (!impulsLeft && impulsRight)
            {
                impulsLeft = true;
                impulsRight = false;
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(-2.5f, 5), ForceMode2D.Impulse);
                bounce.Play();
            }
        }
    }
}