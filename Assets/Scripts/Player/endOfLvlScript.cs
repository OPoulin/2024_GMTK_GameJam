using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfLvlScript : MonoBehaviour
{
    public GameObject endOfLvlZone;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == endOfLvlZone)
        {
            playerManagerScript.Health = playerManagerScript.maxHealth;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
