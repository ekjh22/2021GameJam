using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDetect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Follower"))
        {
            Destroy(collision.gameObject, 1f);
            Debug.Log("팔로우가 잡혔다!!");
        }
    }
}
