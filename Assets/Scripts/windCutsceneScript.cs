using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windCutsceneScript : MonoBehaviour
{
    public GameObject player;
    public bool stopAnimating = false;


    void Start()
    {
        player.GetComponent<Animator>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(GetComponent<townIngredientCollect>().strawberryCollect && GetComponent<townIngredientCollect>().acornCollect)
        if(collision.gameObject.name == "windZoneTrigger")
        {
            player.GetComponent<Animator>().enabled = true;
        }
    }
    void Update()
    {
        if(player.GetComponent<Animator>().enabled == true)
        {
            if (stopAnimating)
            {
                player.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
