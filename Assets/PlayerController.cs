using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;
    public float jumpPower = 100.0f;
    private Rigidbody2D rb;
    private bool canJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float movementForce = speed * horizontalMovement;
        rb.AddForce(Vector2.right * movementForce, ForceMode2D.Impulse);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        canJump = true;
    }
}

