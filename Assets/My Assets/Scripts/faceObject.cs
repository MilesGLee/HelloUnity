using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceObject : MonoBehaviour
{
    public Transform target;
    public bool freezeXZ = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (freezeXZ)
        {
            var lookpos = target.position - transform.position;
            lookpos.y = 0;
            var rot = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5);
        }
        else 
        {
            transform.LookAt(target);
        }
    }
}
