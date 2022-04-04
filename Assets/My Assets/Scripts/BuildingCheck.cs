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
}
