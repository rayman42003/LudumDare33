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
    private bool grounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
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
        if (grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            grounded = false;
        }
    }
}
