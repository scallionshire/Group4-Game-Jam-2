using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : MonoBehaviour
{
    // private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public float moveSpeed = 2.5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        // _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.x == 0 && movement.y == 0) //not moving
        {
            // _animator.SetBool("walking", false);
            // if (FindObjectOfType<AudioManager>().isPlaying("Footsteps1") == true)
            // {
            //     FindObjectOfType<AudioManager>().Pause("Footsteps1");
            // }
        }
        else
        {
            // _animator.SetBool("walking", true);
            // if (FindObjectOfType<AudioManager>().isPlaying("Footsteps1") == false)
            // {
            //     FindObjectOfType<AudioManager>().Play("Footsteps1");
            // }
            if (movement.x == 0)
            {
                if (movement.y == -1) //DOWN: facing down and right
                {
                    movement.x = 1;
                }
                else if (movement.y == 1)
                { //UP: facing up and left
                    movement.x = -1;
                }
            }
            if (movement.y == 0)
            {
                if (movement.x == 1) //RIGHT: facing right and up, FLIP
                {
                    movement.y = 1;
                }
                else if (movement.x == -1) //LEFT: facing left and down, FLIP
                {
                    movement.y = -1;
                }
            }

            if (movement.x != movement.y) //default images are up + left and down + right
            {
                _spriteRenderer.flipX = false;
            } else {
                _spriteRenderer.flipX = true;
            }
            
        }
        updateDirection(movement.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * movement * Time.deltaTime);
    }

    void updateDirection(float y)
    {
        if (y == -1)
        {
            // _animator.SetBool("facingDown", true);
        } else if (y == 1)
        {
            // _animator.SetBool("facingDown", false);
        }
    }
}

