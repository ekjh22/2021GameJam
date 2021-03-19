using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderRotation : MonoBehaviour
{
    public Vector3 mousePosition;
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 l_vector = mousePosition - transform.position;
        transform.rotation = Quaternion.LookRotation(l_vector).normalized;
    }
}
