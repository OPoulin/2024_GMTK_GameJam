using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailPickupScript : MonoBehaviour
{
    public GameObject textBox;
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerManagerScript.nailUnlcoked = true;
        gameObject.SetActive(false);
        textBox.SetActive(true);

        Invoke("kaboom", 6f);
    }

    void kaboom()
    {
        Destroy(textBox);
        Destroy(gameObject);
    }
}
