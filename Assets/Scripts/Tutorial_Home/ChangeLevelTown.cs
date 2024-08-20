using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelTown : MonoBehaviour
{

    public GameObject Player;
    public GameObject Window;
    public GameObject Arrow;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Arrow.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Player.GetComponent<Rigidbody2D>().velocity.y >= 5)
        {
            ChangeSceneTown();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Arrow.SetActive(false);
    }

    void ChangeSceneTown() 
    { 
        MusicManager.musicHouse.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene("TownMarket");
    }
}
