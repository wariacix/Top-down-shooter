using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Image img;
    public Sprite spritePistol, spriteSMG;

    public static int weaponChoice = 1;

    public float bulletSpeed = 12f;

    public float smgSpeed = 10f;

    private float timeDuration = 0f;

    public Text ammoText;

    public static int ammo1 = 60;
    public static int ammo2 = 2000;

    // Update is called once per frame
    void Update()
    {
        if (timeDuration <= smgSpeed) timeDuration += Time.fixedDeltaTime;

        AmmoUpdate();

        if (Input.GetButtonDown("Fire1") & weaponChoice == 1)
        {
            if (ammo1 > 0)
            {
                Shoot();
                ammo1--;
            }
        }
        else if (Input.GetButton("Fire1") & weaponChoice == 2 & timeDuration >= smgSpeed)
        {
            if (ammo2 > 0)
            {
                Shoot();
                ammo2--;
                timeDuration = 0;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void AmmoUpdate()
    {
        int ammo = 0;
        if (Input.GetKeyDown("1"))
        {
            weaponChoice = 1;
            img.sprite = spritePistol;
        }
        if (Input.GetKeyDown("2"))
        {
            weaponChoice = 2;
            img.sprite = spriteSMG;
        }
        if (weaponChoice == 1)
        {
            Color myColor1 = new Color(1, 0, 1, 1);
            ammoText.color = myColor1;
            ammo = ammo1;
        }
        else if (weaponChoice == 2)
        {
            Color myColor2 = new Color(0, 1, 0, 1);
            ammoText.color = myColor2;
            ammo = ammo2;
        }
        ammoText.text = ammo.ToString();
    }
}
