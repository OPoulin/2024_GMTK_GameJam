using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    float x;
    float y;

    // Update is called once per frame
    void LateUpdate()
    {
        //camera follow
        if(target.transform.position.x > minX && target.transform.position.x < maxX)
        {
            x = target.transform.position.x;
        }
        if (target.transform.position.y > minY && target.transform.position.y < maxY)
        {
            y = target.transform.position.y;
        }

        transform.position = new Vector3 (x, y, -10);
    }
}
