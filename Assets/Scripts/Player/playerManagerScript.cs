using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static int Health;
    public static int maxHealth;

    //powerups
    public static bool nailUnlcoked = false;
    public static bool clothUnlocked = false;
    public static bool featherUnlocked = false;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
