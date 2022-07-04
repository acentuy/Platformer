using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Spike
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;

    private float speed = 2f;

    private bool isFacingRight = true;

    private RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 0.1f, groundLayers);
    }
    private void FixedUpdate()
    {
        if (hit.collider != false)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                return;
            }    
            rb.velocity = new Vector2(speed, rb.velocity.y);
            return;
        }        
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);                       
    }

}
