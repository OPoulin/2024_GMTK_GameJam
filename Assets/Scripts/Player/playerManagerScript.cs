using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static int Health = 100;
    public static int maxHealth = 100;

    //powerups
    public static bool nailUnlcoked = true;
    public static bool clothUnlocked = false;
    public static bool featherUnlocked = false;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
