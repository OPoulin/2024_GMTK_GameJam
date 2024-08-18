using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCursor : MonoBehaviour
{

    public UnityEngine.SceneManagement.Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        /*DOES NOT INCLUDE PAUSE MENU*/

        if(scene.name != "TitleScreen")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            print("Cursor gone");
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            print("Cursor appear");
        }
    }
}
