using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteFlames;
    [SerializeField] private float courTime;
    private int index = 0;

    void Start()
    {
        StartCoroutine(flameCouroutin());
    }

    void Update()
    {
        flameCouroutin();
    }

    IEnumerator flameCouroutin()
    {
        while (true)
        {
            yield return new WaitForSeconds(courTime);
            index++;
            if (index == spriteFlames.Count)
            {
                index = 0;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteFlames[index];
        }
    }
}
