using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerDamageScript : MonoBehaviour
{
    public int damage;
    public float iFrameTime;
    public bool iFramesActive = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(collision);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        takeDamage(collision);
    }


    void takeDamage(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!iFramesActive)
            {
                int damageRecieved = collision.gameObject.GetComponent<enemyScript>().damage;
                playerManagerScript.Health -= damageRecieved;


                if (playerManagerScript.Health >= 0)
                {
                    GetComponent<Animator>().SetTrigger("Damage");
                    iFramesActive = true;
                    Invoke("iFrameStop", iFrameTime);
                }
                else
                {
                    iFramesActive= true;
                    Invoke("death", 0f);
                }
            }
        }
    }

    void iFrameStop()
    {
        iFramesActive = false;
    }

    void death()
    {
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<playerMovementScript>().isDead = true;
        GetComponent<Rigidbody2D>().drag = 10;
    }
}
