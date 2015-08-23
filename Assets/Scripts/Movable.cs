using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    
    public static readonly int numJumps = 1;
    private Rigidbody2D body;
    private int jumpsLeft;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumpsLeft = numJumps;
    }

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask))
            jumpsLeft = numJumps;
    }

    public void MoveRight()
    {
        body.velocity = new Vector2(moveSpeed, body.velocity.y);
    }

    public void MoveLeft()
    {
        body.velocity = new Vector2(-moveSpeed, body.velocity.y);
    }

    public void Jump()
    {
        if (jumpsLeft > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            --jumpsLeft;
        }
    }
}
