using FMOD.Studio;
using FMODUnity;
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
    int directionOnMount;
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

    //for feather jump
    bool canDoubleJump;
    public GameObject feather;

    //colliders and raycasts
    public GameObject boxSize;
    public GameObject circleSize;

    Rigidbody2D rb;
    public bool isDead = false;


    //for SFXs
    bool soundParachute = false;
    bool soundMove = false;
    bool soundJump = false;

    //SFX events for player actions
    public FMOD.Studio.EventInstance eventJump;
    public FMOD.Studio.EventInstance eventMove;
    public FMOD.Studio.EventInstance eventclimb;
    public FMOD.Studio.EventInstance eventParachute;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nonGlideSpeed = maxSpeed;

        eventJump = RuntimeManager.CreateInstance(SFX_bank.EventJump);
        eventclimb = RuntimeManager.CreateInstance(SFX_bank.EventWallClimb);
        eventMove = RuntimeManager.CreateInstance(SFX_bank.EventWalk);
        eventParachute = RuntimeManager.CreateInstance(SFX_bank.EventParachute);
    }


    void Update()
    {
        if (!isDead)
        {
            //this works better than clamp for some reason
            if (speed > maxSpeed) { speed = maxSpeed; }
            if (speed < -maxSpeed) { speed = -maxSpeed; }



            //wall jump
            if (playerManagerScript.nailUnlcoked)
            {
                //if (Physics2D.OverlapBox(boxSize.transform.position, boxSize.transform.localScale, 0f) && !Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.499f), 0.15f) && isRunning)
                if (Physics2D.OverlapBox(boxSize.transform.position, boxSize.transform.localScale, 0f) && !Physics2D.OverlapCircle(circleSize.transform.position, circleSize.transform.localScale.x) && isRunning)
                {
                    if (mountControl && !wallMounted)
                    {
                        //wall climb conditions complete
                        //wallMounted = true;

                        GetComponent<SpriteRenderer>().enabled = false;
                        if (runDirection < 0) { wallRideLeft.SetActive(true); }
                        if (runDirection > 0) { wallRideRight.SetActive(true); }

                        wallMounted = true;

                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        rb.gravityScale = 0;
                        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                        speed = 0;

                        directionOnMount = runDirection;

                        eventclimb.start();
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
                if (rb.velocity.y < 0)
                {
                    startGliding();
                    if (soundParachute == false)
                    {
                        eventParachute.start();
                        soundParachute = true;
                    }
                }
                if (Physics2D.OverlapCircle(circleSize.transform.position, circleSize.transform.localScale.x) || wallMounted)
                {
                    stopGliding();
                }
            }



            //if touch floor
            if (Physics2D.OverlapCircle(circleSize.transform.position, circleSize.transform.localScale.x))
            {
                canDoubleJump = true;
                GetComponent<Animator>().SetBool("jumping", false);
            }
        }
        
    }


    public void onJump(InputAction.CallbackContext context)
    {
        if (!isDead)
        {
            if (context.performed)
            {
                if (Physics2D.OverlapCircle(circleSize.transform.position, circleSize.transform.localScale.x))
                {
                    //GetComponent<Animator>().SetBool("jumping", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                }
                else if (wallMounted) //wall jump
                {
                    float wallJumpDirection;

                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;

                    wallJumpDirection = wallJumpHorzontal * -directionOnMount;
                    rb.velocity = new Vector2(wallJumpDirection, wallJumpHeight);

                    mountControl = false;
                    Invoke("regainControll", wallMountDelay);
                }
                else if (playerManagerScript.featherUnlocked) //double jump
                {
                    if (canDoubleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                        canDoubleJump = false;

                        GetComponent<Animator>().SetBool("double jump", true);
                        eventJump.start();
                    }
                }
                GetComponent<Animator>().SetBool("jumping", true);
                if (soundJump == false)
                {
                    eventJump.start();
                    soundJump = true;
                }
            }
        }
    }
    public void doublejumpFeatherAnim()
    {
        if(!isDead)
        {
            feather.SetActive(true);
            //turn the feather depending on where player is facing but doesnt work, fuck it
            /*if(runDirection == 1)
            {
                feather.transform.localScale = new Vector3(1, feather.transform.localScale.y, feather.transform.localScale.z);
            }
            if (runDirection == -1)
            {
                feather.transform.localScale = new Vector3(-1, feather.transform.localScale.y, feather.transform.localScale.z);
            }*/
        }
    }

    public void onRun(InputAction.CallbackContext context)
    {
        if (!isDead)
        {
            if (context.ReadValue<float>() == 0)
            {
                isRunning = false;
                GetComponent<Animator>().SetBool("Running", false);
                eventMove.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            else
            {
                eventMove.start();
                isRunning = true;
                GetComponent<Animator>().SetBool("Running", true);

                if (context.ReadValue<float>() > 0)
                {
                    runDirection = 1;
                }
                else if (context.ReadValue<float>() < 0)
                {
                    runDirection = -1;
                }
            }

            if (!wallMounted)
            {
                if (context.ReadValue<float>() > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (context.ReadValue<float>() < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
    }


    void FixedUpdate()
    {
        if(!isDead)
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
    }



    //gliding
    public void onGlide(InputAction.CallbackContext context)
    {
        if (!isDead)
        {
            if (playerManagerScript.clothUnlocked)
            {
                if (context.performed)
                {
                    //if not on floor and not wall mounted
                    if (!Physics2D.OverlapCircle(circleSize.transform.position, circleSize.transform.localScale.x) && !wallMounted)
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
    }
    void startGliding()
    {
        if(!isDead)
        {
            gliderSprite.SetActive(true);
            rb.drag = gliderFallSpeed * -1;
            maxSpeed = gliderHorizontalSpeed;
        }
    }
    void stopGliding()
    {
        if(!isDead)
        {
            isGliding = false;

            gliderSprite.SetActive(false);
            rb.drag = 0;
            maxSpeed = nonGlideSpeed;
            soundParachute = true;
        }
    }


    //funnction called by wall jumping
    void regainControll()
    {
        if(!isDead)
        {
            //determines if you have control after wall jumping
            speed = rb.velocity.x;
            mountControl = true;
        }
    }
}
