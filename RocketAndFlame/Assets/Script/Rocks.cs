using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    [SerializeField] private Vector3 fallingVecs = new Vector3(0, -1, 0);

    private List<Transform> rockTransforms = new List<Transform>();
    private List<float> rockSpeeds = new List<float>();
    private List<float> rotateSpeeds = new List<float>();

    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            rockTransforms.Add(gameObject.transform.GetChild(i));
            rockSpeeds.Add(Random.Range(3f, 8f));
            rotateSpeeds.Add(Random.Range(-180f, 180f));
        }
    }
    void Update()
    {
        new WaitForSeconds(3f);
        for (int i = 0; i < rockTransforms.Count; i++)
        {
            rockTransforms[i].position += fallingVecs * rockSpeeds[i] * Time.deltaTime;
            rockTransforms[i].eulerAngles += new Vector3(0, 0, 1) * rotateSpeeds[i] * Time.deltaTime;
            if (rockTransforms[i].position.y <= -6)
            {
                rockTransforms[i].position = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(5.5f, 9.5f), 0);
                rockSpeeds.Add(Random.Range(3f, 8f));
                rotateSpeeds.Add(Random.Range(-180f, 180f));
            }
        }
    }
}
