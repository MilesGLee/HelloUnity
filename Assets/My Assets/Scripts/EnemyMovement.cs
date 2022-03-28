using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;

    public float Speed 
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public GameObject Target 
    {
        get { return _target; }
        set { _target = value; }
    }

    public override void Update()
    {
        Vector3 direction = _target.transform.position - transform.position;

        Velocity = direction.normalized * _speed;

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target) 
        {
            Destroy(gameObject);
        }
    }
}
