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
        positionClouds1_2 = skyClouds[1].transform.localPosition.x;
        positionClouds1_3 = skyClouds[2].transform.localPosition.x;

        positionClouds2_2 = skyClouds2[1].transform.localPosition.x;
        positionClouds2_3 = skyClouds2[2].transform.localPosition.x;

        positionClouds3_2 = skyClouds3[1].transform.localPosition.x;
        positionClouds3_3 = skyClouds[2].transform.localPosition.x;

        positionClouds4_2 = skyClouds4[1].transform.localPosition.x;
        positionClouds4_3 = skyClouds[2].transform.localPosition.x;

        skyClouds[2].gameObject.SetActive(false);
        skyClouds2[2].gameObject.SetActive(false);
        skyClouds3[2].gameObject.SetActive(false);
        skyClouds4[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Resets layer 1*/
        if (skyClouds[0].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds[0].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }

        if (skyClouds[1].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds[1].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }
        /*Resets layer 2*/
        if (skyClouds2[0].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds2[0].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }

        if (skyClouds2[1].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds2[1].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }
        /*Resets layer 3*/
        if (skyClouds3[0].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds3[0].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }

        if (skyClouds3[1].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds3[1].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }
        /*Resets layer 4*/
        if (skyClouds4[0].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds4[0].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }

        if (skyClouds4[1].transform.localPosition.x <= positionClouds1_2)
        {
            skyClouds4[1].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        }



        /*WE MAKE EM MOVE*/

        foreach (var a in skyClouds)
        {
            a.transform.localPosition = new Vector2(a.transform.localPosition.x - (moveSpeed * 0.2f), a.transform.localPosition.y);
        }

        foreach (var b in skyClouds2)
        {
            b.transform.localPosition = new Vector2(b.transform.localPosition.x - (moveSpeed * 0.4f), b.transform.localPosition.y);
        }

        foreach (var c in skyClouds3)
        {
            c.transform.localPosition = new Vector2(c.transform.localPosition.x - (moveSpeed * 0.7f), c.transform.localPosition.y);
        }

        foreach (var d in skyClouds4)
        {
            d.transform.localPosition = new Vector2(d.transform.localPosition.x - moveSpeed, d.transform.localPosition.y);
        }


        /*Don't let THEM move*/
        skyClouds[2].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        skyClouds2[2].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        skyClouds3[2].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
        skyClouds4[2].transform.localPosition = new Vector2(positionClouds1_3, skyClouds[0].transform.localPosition.y);
    }
}
