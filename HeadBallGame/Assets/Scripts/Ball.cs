using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 forceInitial;
    [SerializeField] private float groundY;
    [SerializeField] private float obstacleX;
    void Start()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(forceInitial);
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WallBottom" && transform.position.y <= groundY)
        {
            if (transform.position.x <= obstacleX)
            {
                GameManager.instance.ChangeScore(false);
            }
            else
            {
                GameManager.instance.ChangeScore(true);
            }
        }
    }
}
