using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rocketSpeed = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -6.5)
        {
            transform.position += new Vector3(-1, 0, 0) * rocketSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -3.5)
        {
            transform.position += new Vector3(0, -1, 0) * rocketSpeed * Time.deltaTime;
        } 
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 6.5)
        {
            transform.position += new Vector3(1, 0, 0) * rocketSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 3.5)
        {
            transform.position += new Vector3(0, 1, 0) * rocketSpeed * Time.deltaTime;
        }
    }
}
