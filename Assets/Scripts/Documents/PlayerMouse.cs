using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.CircleCast(mouse, 0.5f, Vector3.forward);

            if (hit.collider != null && hit.collider.tag.Equals("Follower"))
            {
            }
        }
    }
}
