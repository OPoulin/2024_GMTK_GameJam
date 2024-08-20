using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    static dontDestroyOnLoad instance;

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

    private void Update()
    {
        if (gameObject.name == "CanvasPause" && SceneManager.GetActiveScene().name == "TitleScreen")
        {
            Destroy(gameObject);
        }
    }
}
