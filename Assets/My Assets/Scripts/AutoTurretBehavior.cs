using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurretBehavior : MonoBehaviour
{
    private Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform head;
    [SerializeField] private Transform gunTip;
    public float force;

    void Start()
    {
        InvokeRepeating("Attack", 1f, 1f);
    }

    void Update()
    {
        target = FindClosestEnemy().transform;
        if(target != null)
            head.LookAt(target);
    }

    public GameObject FindClosestEnemy() 
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("EnemyBody");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Attack() 
    {
        if (target != null)
        {
            GameObject bul = Instantiate(bullet, gunTip.position, Quaternion.identity);
            bul.transform.LookAt(target);
            bul.GetComponent<Rigidbody>().AddForce((target.position - bul.transform.position).normalized * force);
            if (Vector3.Distance(target.position, transform.position) < 50)
            {

            }
        }
    }
}
