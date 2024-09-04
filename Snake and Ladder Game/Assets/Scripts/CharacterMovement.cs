using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float hMovement = 0;
    float vMovement = 0;
    bool isFacingRight = true;

    [SerializeField] float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {        
        Move();
    }

    private void Move()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hMovement * moveSpeed, vMovement * moveSpeed);
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
