using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    // private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public float moveSpeed = 2.5f;
    private float moveLimiter = 0.7f;
    private float horizontal;
    private float vertical;
    public Rigidbody2D rb;

    void Start()
    {
        // _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}

