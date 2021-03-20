using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Scene;

public class Loading : MonoBehaviour
{
    void Start()
    {
        Invoke("WaitStart", 3f);
    }

    void WaitStart()
    {
        Loader.LoaderCallback();
    }
}
