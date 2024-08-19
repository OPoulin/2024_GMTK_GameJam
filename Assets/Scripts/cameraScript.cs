using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private float timeSmooth = 0.25f;
    private Vector3 velocityCamera = Vector3.zero;

    public GameObject target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    /*MAKE CAMERA LIMITS FOR PARTS OF FOREST*/
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //camera follow
        Vector3 targetPosition = target.transform.position + offset;

        if (scene.name == "Forest")
        {
            if (target.transform.position.x <= 11f)
            {
                minY = 0f;
                targetPosition = new Vector3(target.transform.position.x, minY, -10f);
            }
            else if (target.transform.position.x > 11f && target.transform.position.x <= 33f)
            {
                minY = 1.92f;
                targetPosition = new Vector3(target.transform.position.x, minY, -10f);
            }
            else if (target.transform.position.x > 33f && target.transform.position.x <= 65f)
            {
                minY = -17.23f;
                targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
            }
            else if (target.transform.position.x > 65f && target.transform.position.x <= 117f)
            {
                minY = -20.18f;
                targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
            }
            else if (target.transform.position.x > 117f)
            {
                minY = 0.78f;
                targetPosition = new Vector3 (target.transform.position.x, minY, -10f);
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityCamera, timeSmooth);

            if (transform.position.y < minY && transform.position.x > 20f && transform.position.x < 115f)
            {
                transform.position = new Vector3(transform.position.x, minY, -10f);
            }
            else if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, -10f);
            }
        }
        else
        {
            targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityCamera, timeSmooth);

            if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, -10f);
            }
            else if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, -10f);
            }
        }


        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, -10f);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, -10f);
        }


    }
}
