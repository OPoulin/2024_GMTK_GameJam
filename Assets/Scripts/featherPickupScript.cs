using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class featherPickupScript : MonoBehaviour
{
    public GameObject textBox;
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerManagerScript.featherUnlocked = true;
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
