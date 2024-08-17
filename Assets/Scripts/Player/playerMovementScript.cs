using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovementScript : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float deceleration;
    public float jumpHeight;

    //for run
    float speed;
    bool isRunning;
    int runDirection;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void onRun(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;

            if (context.ReadValue<float>() > 0)
            {
                runDirection = 1;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (context.ReadValue<float>() < 0)
            {
                runDirection = -1;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }


    void Update()
    {
        if(Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 0.6f), new Vector2(1,1), 0f))
        {
            print("wall");
        }
    }


    void FixedUpdate()
    {
        if (isRunning)
        {
            speed = speed + (acceleration * runDirection);
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            if(rb.velocity.x != 0)
            {
                if(rb.velocity.x > 0)
                {
                    speed = speed - deceleration;
                }
                else if(rb.velocity.x < 0)
                {
                    speed = speed + deceleration;
                }
            }
            //this line ensures no deceleration due to physics only alowing programmed deceleration
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }


    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed && Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
