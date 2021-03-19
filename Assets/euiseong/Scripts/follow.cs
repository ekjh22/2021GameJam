using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Vector3 followPos;
    public int followDelay;
    public Transform parent;
    public Queue<Vector3> parentPos;

    void Awake()
    {
        parentPos = new Queue<Vector3>();
    }

    void Start()
    {

    }

    void Update()
    {
        Watch();
        Follow();
    }

    void Watch()
    {
        // input parent position
        if (!parentPos.Contains(parent.position))
        {
            parentPos.Enqueue(parent.position);
        }

        // output parent position
        if (parentPos.Count > followDelay)
        {
            followPos = parentPos.Dequeue();
        }
        else if(parentPos.Count < followDelay)
        {
            followPos = parent.position;
        }
    }

    void Follow()
    {
        transform.position = followPos;
    }
}
