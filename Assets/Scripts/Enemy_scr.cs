using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_scr : MonoBehaviour
{
    public int enemyHP = 100;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pistol")
        {
            enemyHP -= 50;
        }
        else if (collision.gameObject.tag == "smg")
        {
            enemyHP -= 20;
        }

        if (enemyHP <= 1) Destroy(gameObject);
    }
}
