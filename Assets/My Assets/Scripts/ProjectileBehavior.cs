using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int damage;

    private void ontr(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            other.GetComponent<EnemyBehavior>().TakeDamage(damage);
        Destroy(gameObject);
    }

    private void Awake()
    {
        StartCoroutine(deathTimer());
    }

    IEnumerator deathTimer() 
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
