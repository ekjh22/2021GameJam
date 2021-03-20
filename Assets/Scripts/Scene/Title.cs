using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Scene;

public class Title : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Loader.Load(Scene.InGame);
    }
}
