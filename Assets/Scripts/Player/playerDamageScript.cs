using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using FMOD.Studio;
using FMODUnity;

public class playerDamageScript : MonoBehaviour
{
    public int damage;
    public float iFrameTime;
    public bool iFramesActive = false;

    public Image HealthBar;

    public GameObject deathSmokeEffect;
    public GameObject nail1;
    public GameObject nail2;
    public GameObject glider;
    public GameObject feather;

    public static EventInstance SFXPlayerDamage;
    public static EventInstance SFXPlayerDeath;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //takeDamage(collision);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        takeDamage(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //takeDamageTrigger(collision);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        takeDamageTrigger(collision);
    }


    void takeDamage(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!iFramesActive)
            {
                int damageRecieved = collision.gameObject.GetComponent<enemyScript>().damage;
                playerManagerScript.Health -= damageRecieved;

                RuntimeManager.PlayOneShot(SFX_bank.EventPlayerDamage);

                //decrease healthbar
                float barFill = (float)playerManagerScript.Health / (float)playerManagerScript.maxHealth;
                HealthBar.fillAmount = barFill;

                if (playerManagerScript.Health > 0)
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
    void takeDamageTrigger(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!iFramesActive)
            {
                int damageRecieved = collision.gameObject.GetComponent<enemyScript>().damage;
                playerManagerScript.Health -= damageRecieved;

                RuntimeManager.PlayOneShot(SFX_bank.EventPlayerDamage);

                //decrease healthbar
                float barFill = (float)playerManagerScript.Health / (float)playerManagerScript.maxHealth;
                HealthBar.fillAmount = barFill;

                if (playerManagerScript.Health > 0)
                {
                    GetComponent<Animator>().SetTrigger("Damage");
                    iFramesActive = true;
                    Invoke("iFrameStop", iFrameTime);
                }
                else
                {
                    iFramesActive = true;
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
        RuntimeManager.PlayOneShot(SFX_bank.EventPlayerDeath);
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<playerMovementScript>().isDead = true;
        GetComponent<Rigidbody2D>().drag = 10;
        playerMovementScript.eventMove.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Invoke("pouf", 1);
    }
    void pouf()
    {
        deathSmokeEffect.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        nail1.SetActive(false);
        nail2.SetActive(false);
        glider.SetActive(false);
        feather.SetActive(false);
        Invoke("resetScene", 1.25f);
    }
    void resetScene()
    {
        playerManagerScript.Health = playerManagerScript.maxHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
