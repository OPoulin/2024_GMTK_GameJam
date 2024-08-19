using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratBehaviorScript : MonoBehaviour
{
    public float ratSpeed = 1.38f;
    public float minX;
    public float maxX;
    public int direction;

    public bool isIdle;

    public bool isAttacking;

    bool canTurn = true;

    public GameObject player;

    float scale;
    Rigidbody2D rb;


    private void Start()
    {
        if (name != "Plant") 
        { 
            GetComponent<Animator>().SetBool("isWalk", true);
        }

        isIdle = false;
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
        print(scale);
    }
    void Update()
    {
            float speed;

        if (name == "rat")
        {
            if(!isIdle)
            {
                GetComponent<Animator>().SetBool("isWalk", true);
                speed = ratSpeed * direction;
                rb.velocity = new Vector2(speed, 0);

                //change direction when hit limit
                if(transform.localPosition.x < minX)
                {
                    direction = 1;
                }
                if (transform.localPosition.x > maxX)
                {
                    direction = -1;
                }

                if(direction == 1)
                {
                    transform.localScale = new Vector2((scale * -1), transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2((scale), transform.localScale.y);
                }
            }
        }
        
        
        
        if (name == "MushroomMan")
        {
            if (!isIdle)
            {
                GetComponent<Animator>().SetBool("isWalk", true);
                speed = ratSpeed * direction;
                rb.velocity = new Vector2(speed, 0);

                //change direction when hit limit
                if (transform.localPosition.x < minX)
                {
                    direction = 1;
                }
                if (transform.localPosition.x > maxX)
                {
                    direction = -1;
                }

                if (direction == 1)
                {
                    transform.localScale = new Vector2((scale * -1), transform.localScale.y);
                }
                else
                {
                    transform.localScale = new Vector2((scale), transform.localScale.y);
                }
            }

            if (GetComponent<Animator>().GetBool("isAttack") == true && !isIdle)
            {
                RuntimeManager.PlayOneShot(SFX_bank.EventMushroomAttack);
                print("I'm bouta attack");
                Invoke("AttackFalse", 1.2f);
                isIdle = true;
                GetComponent<Animator>().SetBool("isWalk", false);
                speed = 0;
                rb.drag = 1500f;
                GetComponent<Animator>().SetBool("isWalk", false);
                CancelInvoke("IdleFalse");
                Invoke("IdleFalse", 1.6f);
            }
        }
        
        
        if (name == "Plant")
        {

            if (GetComponent<Animator>().GetBool("isAttack") == true && isIdle == false)
            {
                RuntimeManager.PlayOneShot(SFX_bank.EventPlantAttack);
                print("I'm bouta attack");
                Invoke("AttackFalse", 1f);
                Invoke("IdleFalse", 1f);
                isIdle = true;
                canTurn = false;
            }

            if (canTurn)
            {
                if (player.transform.position.x - transform.position.x > 0)
                {
                    transform.localScale = new Vector2 (scale * -1, transform.localScale.y);
                } 
                else if (player.transform.position.x - transform.position.x < 0)
                {
                    transform.localScale = new Vector2 (scale, transform.localScale.y);
                }
                print("I will turn");
            }

            print(player.transform.position.x - transform.position.x);
        }
    }

    void AttackFalse()
    {
        GetComponent<Animator>().SetBool("isAttack", false);
    }

    void IdleFalse()
    {
        canTurn = true;
        isIdle = false;
        rb.drag = 0f;
    }
}
