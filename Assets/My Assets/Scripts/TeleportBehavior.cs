using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    public Transform endPos;
    public Transform Target;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(Target.position, transform.position) < 5) 
        {
            Target.position = endPos.position;
        }
    }
}
