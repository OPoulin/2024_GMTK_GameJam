using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTriggerattack : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.GetComponent<Animator>().SetBool("isAttack", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.GetComponent<Animator>().SetBool("isAttack", true);
        }
    }
}
