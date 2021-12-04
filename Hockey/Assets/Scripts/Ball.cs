using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    private Vector2 curVelocity;

    private void Update()
    {
        curVelocity = transform.GetComponent<Rigidbody2D>().velocity;
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight")
        {
            transform.GetComponent<Rigidbody2D>().velocity = curVelocity * new Vector2(-1, 1);
        }

        if (collision.gameObject.name == "PadPlayer")
        {
            GameManager.instance.changeScore(false);
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (collision.gameObject.name == "PadEnemy")
        {
            GameManager.instance.changeScore(true);
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
