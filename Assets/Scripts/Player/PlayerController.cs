using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string horizontalAxisName = "Horizontal";
    public string jumpName = "Jump";
    public float horizontal { get; private set; }
    public bool jump { get; private set; }
    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalAxisName);
        jump = Input.GetButtonDown(jumpName);
    }
}
