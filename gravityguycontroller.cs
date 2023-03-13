using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovementgravityguy : MonoBehaviour
{
private Rigidbody2D rb2d;
public float speed = 15.0f;
public float maxSpeed = 30.0f;
public GameObject weapon;
public float rotation = 180.0f;
private bool canJump = true;
private float elapsedTime = 0.0f;


void Start()
{
    rb2d = GetComponent<Rigidbody2D>();
}

public void Jump()
{
    if (canJump)
    {
        rb2d.gravityScale *= -1;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        canJump = false;
    }
}

public void Fire()
{
    weapon.GetComponent<weapon>().Fire();
}

// Update is called once per frame
void Update()
{
    elapsedTime += Time.deltaTime;
    if (elapsedTime >= 1.0f)
    {
        speed = Mathf.Min(speed + 1, maxSpeed);
        elapsedTime = 0.0f;
    }

    float horizontal = Input.GetAxis("Horizontal");

    Vector2 velocity = new Vector2(speed, rb2d.velocity.y);

   
    rb2d.velocity = velocity;

    if (rb2d.velocity.y == 0)
    {
        canJump = true;
    }
}
}
