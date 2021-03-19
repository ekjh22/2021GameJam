using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string horizontalAxisName = "Horizontal";

    public float horizontal { get; private set; }

    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalAxisName);

    }
}
