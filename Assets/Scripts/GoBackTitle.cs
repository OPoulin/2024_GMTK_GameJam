using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackTitle : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addFrames", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 20)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }



    void addFrames()
    {
        timer += 1;
    }
}
