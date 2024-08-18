using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitchScript : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    public bool oneUse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cam1.active)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }

        if (oneUse)
        {
            Destroy(gameObject);
        }
    }
}
