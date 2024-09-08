using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float hMovement = 0;
    float vMovement = 0;
    bool isFacingRight = true;
    Animator animator;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
    }

    private void Update()
    {        
        Move();
        FlipCharacter();
    }

    private void Move()
    {
        hMovement = Input.GetAxisRaw("Horizontal");        
        if(hMovement != 0 || vMovement != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hMovement * moveSpeed, rb.velocity.y);
    }

    void FlipCharacter()
    {
        if (hMovement > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (hMovement < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }
}
