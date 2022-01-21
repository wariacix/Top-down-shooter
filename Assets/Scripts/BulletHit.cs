using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject hitEffect;

    public SpriteRenderer spr;

    public Sprite pistol, smg;

    private float bulletDMG;

    private int effectChoice;

    void Start()
    {
        if (Shooting.weaponChoice == 1)
        {
            bulletDMG = 50;
            spr.sprite = pistol;
            effectChoice = 1;
            gameObject.tag = "pistol";
        }
        else if (Shooting.weaponChoice == 2)
        {
            bulletDMG = 20;
            spr.sprite = smg;
            effectChoice = 2;
            gameObject.tag = "smg";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        SpriteRenderer sprEff = effect.GetComponent<SpriteRenderer>();
        if (effectChoice == 1)
        {
            sprEff.color = Color.white;
        }
        else if (effectChoice == 2)
        {
            sprEff.color = new Color(0.5f, 1, 0, 1);
        }
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
}
