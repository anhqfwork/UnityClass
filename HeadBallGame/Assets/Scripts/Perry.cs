using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perry : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private Vector3 newPos = new Vector3();
    private void Start()
    {
        newPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            newPos = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        } else if (Input.GetKey(KeyCode.A))
        {
            newPos = transform.position + new Vector3(- speed * Time.deltaTime, 0, 0);
        }

        if (newPos.x >= leftBorder && newPos.x <= rightBorder)
        {
            transform.position = newPos;
        }
    }
}
