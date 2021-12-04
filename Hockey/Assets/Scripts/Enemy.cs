using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ball;
    [SerializeField] private float borderLeft;
    [SerializeField] private float borderRight;

    private float ballDestinationX;
    private float timeArrive;
    private Vector2 ballVelo;

    void Update()
    {
        ballVelo = ball.transform.GetComponent<Rigidbody2D>().velocity;
        timeArrive = (transform.position.y - ball.transform.position.y) / ballVelo.y;
        if (timeArrive > 0.1)
        {
            ballDestinationX = ball.transform.position.x + timeArrive * ballVelo.x;
            if (ballDestinationX > transform.position.x && transform.position.x < borderRight)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else if (ballDestinationX < transform.position.x && transform.position.x > borderLeft)
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
