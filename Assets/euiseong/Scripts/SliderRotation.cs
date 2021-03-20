using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderRotation : MonoBehaviour
{
    public float speed = 5f;
    public PlayerMove playermove;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = CheckPositiveAngle(angle);

        transform.localScale = new Vector3(playermove.elapsedTime, transform.localScale.y, transform.localScale.z);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
    float CheckPositiveAngle(float angle)
    {
        if(angle <= -90 && angle >= -180)
        {
            angle = 180;
        }
        else if(angle > -90 && angle <= 0)
        {
            angle = 0;
        }
        return angle;
    }
}
