using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratBehaviorScript : MonoBehaviour
{
    public static float ratSpeed = 1.38f;
    public float minX;
    public float maxX;
    public int direction;

    public bool isIdle;

    float scale;
    Rigidbody2D rb;


    private void Start()
    {
        GetComponent<Animator>().SetBool("isWalk", true);

        isIdle = false;
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
    void Update()
    {
            float speed;

        if(!isIdle)
        {
            GetComponent<Animator>().SetBool("isWalk", true);
            speed = ratSpeed * direction;
            rb.velocity = new Vector2(speed, 0);

            //change direction when hit limit
            if(transform.localPosition.x < minX)
            {
                direction = 1;
            }
            if (transform.localPosition.x > maxX)
            {
                direction = -1;
            }

            if(direction == 1)
            {
                transform.localScale = new Vector2((scale * -1), transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2((scale), transform.localScale.y);
            }
        }
    }
}
