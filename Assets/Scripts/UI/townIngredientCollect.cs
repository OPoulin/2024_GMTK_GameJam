using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using FMODUnity;
using FMOD.Studio;

public class townIngredientCollect : MonoBehaviour
{
    public float desiredShrink;
    //public float shrinkSpeed;
    public float shrinkDelay;
    bool isShrinking = false;

    public Image strawberry;
    public Image acorn;
    public Image mushroom;

    public bool strawberryCollect = false;
    public bool acornCollect = false;
    public bool mushroomCollect = false;

    EventInstance SFXChargeBegin;


    private void Start()
    {
        SFXChargeBegin = RuntimeManager.CreateInstance(SFX_bank.EventPlayerChargeBegin);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ingredient")
        {
            if(collision.gameObject.name == "ingredientStrawberry")
            {
                strawberryCollect = true;
                strawberry.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "ingredientAcorn")
            {
                acornCollect = true;
                acorn.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "ingredientMushroom")
            {
                mushroomCollect = true;
                mushroom.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);

                shrink();
            }
        }
    }
    public void shrink()
    {
        SFXChargeBegin.start();
        GetComponent<Animator>().SetBool("Charge", true);
        GetComponent<PlayerInput>().enabled = false;
        Invoke("startShrink", shrinkDelay);
    }

    void FixedUpdate()
    {
        if (GetComponent<Animator>().GetBool("Charge"))
        {
            if (isShrinking)
            {
                    transform.localScale = new Vector3(desiredShrink, desiredShrink, desiredShrink);
                    Invoke("stopShrink", shrinkDelay);
            }
        }
    }

    void startShrink()
    {
        isShrinking = true;
    }
    void stopShrink()
    {
        isShrinking = false;
        SFXChargeBegin.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        RuntimeManager.PlayOneShot(SFX_bank.EventPlayerChargeEnd);
        GetComponent<Animator>().SetBool("Charge", false);
        GetComponent<PlayerInput>().enabled = true;
    }
}
