using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    Rigidbody2D rb;

    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        float xMov = Input.GetAxis("Horizontal") * speed;

        rb.velocity = new Vector2(xMov, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }

        if (facingRight && xMov < 0)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
            facingRight = false;
        }
        else if (!facingRight && xMov > 0)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
            facingRight = true;
        }
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
    }
}
