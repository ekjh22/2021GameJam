using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleDetect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Obstacle"))
        {
            Debug.Log("장애물에 맞았다!!");
        }
    }
}
