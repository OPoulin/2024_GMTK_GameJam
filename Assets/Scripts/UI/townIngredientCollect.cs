using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class townIngredientCollect : MonoBehaviour
{
    public bool strawberryCollect = false;
    public bool acornCollect = false;
    public bool mushroomCollect = false;

    public Image strawberry;
    public Image acorn;
    public Image mushroom;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ingredient")
        {
            if(collision.gameObject.name == "ingredientStrawberry")
            {
                strawberryCollect = true;
                strawberry.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "ingredientAcorn")
            {
                acornCollect = true;
                acorn.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "ingredientMushroom")
            {
                mushroomCollect = true;
                mushroom.color = new Color(255, 255, 255);
                Destroy(collision.gameObject);
            }
        }
    }
}
