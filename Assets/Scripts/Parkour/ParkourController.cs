using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourController : MonoBehaviour
{
    public SpriteRenderer sr;
    public float speed;
    public float jumpForce;

    private float moveInput;
    private Rigidbody2D rb;

    private bool IsGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    bool IsTouchingFront;
    public Transform frontCheck;
    bool WallSliding;
    public float WallSlidingSpeed;
    public LayerMask WhatIsWall;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0) { sr.flipX = false; }
        else if (moveInput < 0) { sr.flipX = true; }   
        //JUMP
        if(IsGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        //WALLJUMP

        IsTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, WhatIsWall);
        
        if(IsTouchingFront == true && IsGrounded == false && moveInput != 0)
        {
            WallSliding = true;
        }
        else
        {
            WallSliding = false;
        }
        
        if(WallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }

    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
