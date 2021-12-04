using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float ballVelocity;
    [SerializeField] private GameObject ball;
    [SerializeField] private float borderTop;
    [SerializeField] private float borderBot;
    [SerializeField] private float borderLeft;
    [SerializeField] private float borderRight;

    private Vector3 velocityAngle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= borderRight)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= borderLeft)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= borderTop)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y >= borderBot)
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            velocityAngle = ball.transform.position - transform.position;
            ball.GetComponent<Rigidbody2D>().velocity = (Vector2)velocityAngle * ballVelocity;
        }
    }
}
