using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent nav;
    public int health = 1;
    public Transform target;
    public int damage;
    private bool attackInterval;
    public WorldManager _wm;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
    }

    void Update()
    {
        if (health <= 0)
        {
            _wm.playerScore += 100;
            Destroy(gameObject);
        }
        if (Vector3.Distance(target.position, transform.position) < 5 && attackInterval == false)
        {
            StartCoroutine(attack());
        }
        if (_wm.gameOver == true)
            Destroy(gameObject);
    }

    IEnumerator attack() 
    {
        attackInterval = true;
        yield return new WaitForSeconds(3f);
        target.GetComponent<CoreManager>().TakeDamage(damage);
        attackInterval = false;
        StopCoroutine(attack());
    }

    public void TakeDamage(int amount) 
    {
        health = health - amount;
    }
}
