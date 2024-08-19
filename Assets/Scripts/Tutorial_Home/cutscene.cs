using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cutscene : MonoBehaviour
{
    public bool doTheThing;

    public GameObject witch;
    public bool cantMove = true;


    void Start()
    {
        witch.GetComponent<PlayerInput>().enabled = false;
    }


    void Update()
    {
        if (doTheThing)
        {
            witch.GetComponent<townIngredientCollect>().shrink();
            cantMove = true;
        }

        if (cantMove)
        {
            witch.GetComponent<PlayerInput>().enabled = false;
        }
        else
        {
            witch.GetComponent<PlayerInput>().enabled = true;
        }
    }
}
