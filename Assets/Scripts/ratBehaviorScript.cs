using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratBehaviorScript : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int damage;

    public float ratSpeed;
    public float minX;
    public float maxX;
    public int direction;

    public bool isIdle;

    float scale;
    Rigidbody2D rb;


    private void Start()
    {
        isIdle = false;
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale.x;
    }
    void fixedUpdate()
    {
            float speed;

        if(!isIdle)
        {
            GetComponent<Animator>().SetBool("isWalk", true);
            speed = ratSpeed * direction;
            rb.velocity = new Vector2(speed, 0);

            //change direction when hit limit
            if(transform.position.x < minX)
            {
                print("turn left");
                direction = 1;
                transform.localScale = new Vector2( (scale * -1) , transform.localScale.y);
            }
            if (transform.position.x > maxX)
            {
                print("turn right");
                direction = -1;
                transform.localScale = new Vector2((scale), transform.localScale.y);
            }
        }
    }
}
