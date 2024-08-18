using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSkyboxOutside : MonoBehaviour
{
    public GameObject[] skyClouds;
    public GameObject[] skyClouds2;
    public GameObject[] skyClouds3;
    public GameObject[] skyClouds4;

    public float moveSpeed;

    float positionClouds1_1;
    float positionClouds1_2;
    float positionClouds1_3;

    float positionClouds2_1;
    float positionClouds2_2;
    float positionClouds2_3;

    float positionClouds3_1;
    float positionClouds3_2;
    float positionClouds3_3;

    float positionClouds4_1;
    float positionClouds4_2;
    float positionClouds4_3;
    // Start is called before the first frame update
    void Start()
    {
        positionClouds1_2 = skyClouds[1].transform.position.x;
        positionClouds1_3 = skyClouds[2].transform.position.x;

        positionClouds2_2 = skyClouds2[1].transform.position.x;
        positionClouds2_3 = skyClouds2[2].transform.position.x;

        positionClouds3_2 = skyClouds3[1].transform.position.x;
        positionClouds3_3 = skyClouds[2].transform.position.x;

        positionClouds4_2 = skyClouds4[1].transform.position.x;
        positionClouds4_3 = skyClouds[2].transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Resets layer 1*/
        if (skyClouds[0].transform.position.x <= positionClouds1_2)
        {
            skyClouds[0].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }

        if (skyClouds[1].transform.position.x <= positionClouds1_2)
        {
            skyClouds[1].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }
        /*Resets layer 2*/
        if (skyClouds2[0].transform.position.x <= positionClouds1_2)
        {
            skyClouds2[0].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }

        if (skyClouds2[1].transform.position.x <= positionClouds1_2)
        {
            skyClouds2[1].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }
        /*Resets layer 3*/
        if (skyClouds3[0].transform.position.x <= positionClouds1_2)
        {
            skyClouds3[0].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }

        if (skyClouds3[1].transform.position.x <= positionClouds1_2)
        {
            skyClouds3[1].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }
        /*Resets layer 4*/
        if (skyClouds4[0].transform.position.x <= positionClouds1_2)
        {
            skyClouds4[0].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }

        if (skyClouds4[1].transform.position.x <= positionClouds1_2)
        {
            skyClouds4[1].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        }



        /*WE MAKE EM MOVE*/

        foreach (var a in skyClouds)
        {
            a.transform.position = new Vector2(a.transform.position.x - (moveSpeed * 0.2f), a.transform.position.y);
        }

        foreach (var b in skyClouds2)
        {
            b.transform.position = new Vector2(b.transform.position.x - (moveSpeed * 0.4f), b.transform.position.y);
        }

        foreach (var c in skyClouds3)
        {
            c.transform.position = new Vector2(c.transform.position.x - (moveSpeed * 0.7f), c.transform.position.y);
        }

        foreach (var d in skyClouds4)
        {
            d.transform.position = new Vector2(d.transform.position.x - moveSpeed, d.transform.position.y);
        }


        /*Don't let THEM move*/
        skyClouds[2].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        skyClouds2[2].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        skyClouds3[2].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
        skyClouds4[2].transform.position = new Vector2(positionClouds1_3, skyClouds[0].transform.position.y);
    }
}
