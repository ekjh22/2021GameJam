using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platform;

    [Range(0, 2f)]
    public float time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(platform, time);
            Debug.Log("부서지는 플랫폼!!");
        }
    }
}
