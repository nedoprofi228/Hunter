using System;
using UnityEngine;

public class mobController : MonoBehaviour
{
    public  float speed = 1;
    private float directionX;
    private int directionY;
    private bool facingLeft = true;

    public bool isLife = true;
    public bool killedByPlayer = false;
    public bool playerInExplotion = false;

    Rigidbody2D rb;

    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        Debug.Log(player.name);
        transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    private void FixedUpdate()
    {
        Walk();
        rb.velocity = new Vector2(directionX * speed * Time.deltaTime, directionY * speed * Time.deltaTime);
    }
    void Walk()
    {
        Debug.Log("walk");
        if (transform.position.x > player.gameObject.transform.position.x)
        {
            if (transform.position.x + 0.2f < player.gameObject.transform.position.x)
                directionX = 0;
            else
                directionX = -1;
        }
        else
        {
            if (transform.position.x + 0.2f > player.gameObject.transform.position.x)
                directionX = 0;
            else
                directionX = 1;
        }
        if (transform.position.y > player.gameObject.transform.position.y)
        {
            directionY = -1;
        }
        else
        {
            directionY = 1;
        }
        Flip();

    }
    void Flip()
    {
        if ((directionX > 0 && facingLeft) || (directionX < 0) && !facingLeft)
        {
            facingLeft = !facingLeft;
            transform.localScale *= new Vector2(-1, 1);
        }

    }
}
