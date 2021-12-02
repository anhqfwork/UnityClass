using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heinz : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    private bool isMovingRight = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= rightBorder)
            {
                isMovingRight = false;
            }
        } else
        {
            transform.position += new Vector3(- speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= leftBorder)
            {
                isMovingRight = true;
            }
        }
    }
}
