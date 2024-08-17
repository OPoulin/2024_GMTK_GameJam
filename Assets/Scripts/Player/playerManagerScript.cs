using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public static int Health;
    public static int maxHealth;

    //powerups
    public static bool nailUnlcoked = true;
    public static bool clothUnlocked = true;
    public static bool featherUnlocked = true;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
