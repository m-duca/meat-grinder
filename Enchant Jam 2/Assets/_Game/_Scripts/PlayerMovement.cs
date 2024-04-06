using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform feetPosition;
    public float groundDistance = 0.2f;
    public float jumpTime = 0.3f;

    bool isGrounded = false;
    bool isJumping = false;
    float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump")) //Se pressionar, pula mais alto
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump")) //Se apertar uma vez, pula
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }
}
