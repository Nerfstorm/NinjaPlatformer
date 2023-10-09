using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCharacterMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private Vector2 jumpVelocity;

    private bool isGrounded;

    public static bool isWon;
    public static bool isLost; private bool lost;

    private int extraJumps;

    public Transform groundCheck;
    public Transform deathCheck;
    public float checkRadius;

    public LayerMask whatIsGround;
    public LayerMask whatIsWin;
    public LayerMask whatIsLose;

    public int extraJumpsValue;
    

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        isWon = false;
        isLost = false;
    }

    void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isWon = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsWin);
        isLost = Physics2D.OverlapCircle(deathCheck.position, checkRadius, whatIsLose);

        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }
}
