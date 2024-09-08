using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    Rigidbody2D rb;
    // bool isGrounded;
    Animator animator;
    Vector2 vecGravity;

    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier = 2f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] GameObject sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        JumpAnimation();
    }

    private void JumpAnimation()
    {
        if (!IsGrounded())
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.3f), CapsuleDirection2D.Horizontal, 0, layerMask);
    }
}
