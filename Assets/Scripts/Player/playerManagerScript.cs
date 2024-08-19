using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static int Health = 100;
    public static int maxHealth = 100;

    //powerups
    public static bool nailUnlcoked = false;
    public static bool clothUnlocked = false;
    public static bool featherUnlocked = false;

    static playerManagerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }

    void Start()
    {

    }
}
