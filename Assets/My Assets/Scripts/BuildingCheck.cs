using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCheck : MonoBehaviour
{
    public bool check;

    private void OnCollisionStay(Collision collision)
    {
        check = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        check = false;
    }
    private void Update()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
