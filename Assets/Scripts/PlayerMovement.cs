using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float movingSpeed = 5f;

    public Rigidbody2D playerRb;

    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * movingSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - playerRb.position;
        float rotAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        playerRb.rotation = rotAngle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerRb.velocity = new Vector2(0f, 0f);
    }
}
