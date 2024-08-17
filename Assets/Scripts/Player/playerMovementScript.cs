using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovementScript : MonoBehaviour
{
    public float maxSpeed = 5;
    public float acceleration;
    public float deceleration;
    public float jumpHeight;

    //for run
    float speed;
    bool isRunning;
    int runDirection;

    //for wall jump
    public float wallJumpHeight;
    public float wallJumpHorzontal;
    bool wallMounted = false;
    public float wallMountDelay;
    public GameObject wallRideRight;
    public GameObject wallRideLeft;
    //affects mouvement and mounting
    bool mountControl = true;

    //for glider cloth
    bool isGliding = false;
    public GameObject gliderSprite;
    public float gliderFallSpeed;
    public float gliderHorizontalSpeed;
    float nonGlideSpeed;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nonGlideSpeed = maxSpeed;
    }


    void Update()
    {
        //this works better than clamp for some reason
        if (speed > maxSpeed) { speed = maxSpeed; }
        if (speed < -maxSpeed) { speed = -maxSpeed; }



        //wall jump
        if (playerManagerScript.nailUnlcoked)
        {
            if (Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 0.6f), new Vector2(1, 1), 0f) && !Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f) && isRunning)
            {
                if (mountControl)
                {
                    //wall climb conditions complete
                    wallMounted = true;

                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rb.gravityScale = 0;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    speed = 0;

                    GetComponent<SpriteRenderer>().enabled = false;
                    if (runDirection < 0) { wallRideLeft.SetActive(true); }
                    if (runDirection > 0) { wallRideRight.SetActive(true); }
                }
            }
            else
            {
                if (rb.velocity.magnitude != 0)
                {
                    //wallMounted determines if can jump when mounted on wall
                    wallMounted = false;
                    rb.gravityScale = 1;

                    GetComponent<SpriteRenderer>().enabled = true;
                    wallRideLeft.SetActive(false);
                    wallRideRight.SetActive(false);
                }
            }
        }



        //gliding
        if (isGliding)
        {
            if(rb.velocity.y < 0)
            {
                startGliding();
            }
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f) || wallMounted)
            {
                stopGliding();
            }
        }
    }


    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            else if (wallMounted)
            {
                float wallJumpDirection;

                wallJumpDirection = wallJumpHorzontal * -runDirection;
                rb.velocity = new Vector2(wallJumpDirection, wallJumpHeight);

                mountControl = false;
                Invoke("regainControll", wallMountDelay);
            }
        }
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


    void FixedUpdate()
    {
        if (isRunning)
        {
            speed = speed + (acceleration * runDirection);
            //speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            //if(speed > maxSpeed) { speed = maxSpeed;}
            //if(speed < -maxSpeed) { speed = -maxSpeed;}
        }
        else
        {
            if (rb.velocity.x != 0)
            {
                if (rb.velocity.x > 0)
                {
                    speed = speed - deceleration;
                }
                else if (rb.velocity.x < 0)
                {
                    speed = speed + deceleration;
                }
            }
        }
        if (mountControl)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }



    //gliding
    public void onGlide(InputAction.CallbackContext context)
    {
        if (playerManagerScript.clothUnlocked)
        {
            if (context.performed)
            {
                //if not on floor and not wall mounted
                if (!Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f) && !wallMounted)
                {
                    isGliding = true;
                }
            }
            if (context.canceled)
            {
                stopGliding();
            }
        }
    }
    void startGliding()
    {
        gliderSprite.SetActive(true);
        rb.drag = gliderFallSpeed*-1;
        maxSpeed = gliderHorizontalSpeed;
    }
    void stopGliding()
    {
        isGliding = false;

        gliderSprite.SetActive(false);
        rb.drag = 0;
        maxSpeed = nonGlideSpeed;
    }


    //funnction called by wall jumping
    void regainControll()
    {
        //determines if you have control after wall jumping
        speed = rb.velocity.x;
        mountControl = true;
    }
}
