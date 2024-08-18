using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingSkyboxHouse : MonoBehaviour
{
    public GameObject[] skyBackgrounds;
    public GameObject[] skyStars;
    public GameObject[] skyClouds;

    public float moveSpeed;

    float positionSky1;
    float positionSky2;
    float positionSky3;

    float positionStar1;
    float positionStar2;
    float positionStar3;

    float positionClouds1;
    float positionClouds2;
    float positionClouds3;

    public UnityEngine.SceneManagement.Scene sceneTitle;

    // Start is called before the first frame update
    void Start()
    {
        sceneTitle = SceneManager.GetActiveScene();


        if (sceneTitle.buildIndex != 0)
        {
            positionSky2 = skyBackgrounds[1].transform.position.x;
            positionSky3 = skyBackgrounds[2].transform.position.x;

            positionStar2 = skyStars[1].transform.position.x;
            positionStar3 = skyStars[2].transform.position.x;
        }
            positionClouds2 = skyClouds[1].transform.position.x;
            positionClouds3 = skyClouds[2].transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sceneTitle.buildIndex != 0) 
        { 
            /*Reset Background*/
            if (skyBackgrounds[0].transform.position.x <= positionSky2)
            {
                skyBackgrounds[0].transform.position = new Vector2(positionSky3, skyBackgrounds[0].transform.position.y);
            }

            if (skyBackgrounds[1].transform.position.x <= positionSky2)
            {
                skyBackgrounds[1].transform.position = new Vector2(positionSky3, skyBackgrounds[0].transform.position.y);
            }
            /*Reset Stars*/
            if (skyStars[0].transform.position.x <= positionStar2)
            {
                skyStars[0].transform.position = new Vector2(positionStar3, skyStars[0].transform.position.y);
            }

            if (skyStars[1].transform.position.x <= positionStar2)
            {
                skyStars[1].transform.position = new Vector2(positionStar3, skyStars[0].transform.position.y);
            }
            /*Reset Clouds*/
            if (skyClouds[0].transform.position.x <= positionClouds1)
            {
                skyClouds[0].transform.position = new Vector2(positionClouds3, skyClouds[0].transform.position.y);
            }

            if (skyClouds[1].transform.position.x <= positionClouds1)
            {
                skyClouds[1].transform.position = new Vector2(positionClouds3, skyClouds[0].transform.position.y);
            }
        }
        else
        {
            /*Reset Clouds*/
            if (skyClouds[0].transform.position.x <= positionClouds2)
            {
                skyClouds[0].transform.position = new Vector2(positionClouds3, skyClouds[0].transform.position.y);
            }

            if (skyClouds[1].transform.position.x <= positionClouds2)
            {
                skyClouds[1].transform.position = new Vector2(positionClouds3, skyClouds[0].transform.position.y);
            }
        }

        /*Moving the elements*/

        foreach (var x in skyBackgrounds)
        {
            x.transform.position = new Vector2(x.transform.position.x - (moveSpeed * 0.4f), x.transform.position.y);
        }

        foreach (var y in skyStars)
        {
            y.transform.position = new Vector2(y.transform.position.x - (moveSpeed * 0.7f), y.transform.position.y);
        }

        foreach (var z in skyClouds)
        {
            z.transform.position = new Vector2(z.transform.position.x - moveSpeed, z.transform.position.y);
        }

        /*Keep them in place*/
        if(sceneTitle.buildIndex != 0)
        {
        skyBackgrounds[2].transform.position = new Vector2(positionSky3, skyBackgrounds[0].transform.position.y);
        skyStars[2].transform.position = new Vector2(positionStar3, skyStars[0].transform.position.y);
        }
        skyClouds[2].transform.position = new Vector2(positionClouds3, skyClouds[0].transform.position.y);

    }
}
