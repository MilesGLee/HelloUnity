using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 hitPoint;
    public Transform gunTip, cam, player;
    private bool shot = false;
    [SerializeField] private LayerMask shootable;
    [SerializeField] private GrapplingHook gh;
    [SerializeField] private int damage; 

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<PlayerManager>().hasGrapple && gh.grappling == false)
        {
            StartShoot();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, shootable))
        {
            hitPoint = hit.point;
            shot = true;
            lr.positionCount = 2;
            currentShootPosition = gunTip.position;

            if (hit.transform.tag == "Enemy") 
            {
                hit.transform.GetComponent<EnemyBehavior>().TakeDamage(damage);
            }

            StartCoroutine(StopShoot());
        }
    }

    IEnumerator StopShoot() 
    {
        yield return new WaitForSeconds(0.1f);
        lr.positionCount = 0;
        shot = false;
        StopCoroutine(StopShoot());
    }

    private Vector3 currentShootPosition;

    void DrawRope()
    {
        if (!shot) return;
        currentShootPosition = Vector3.Lerp(currentShootPosition, hitPoint, Time.deltaTime * 10f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentShootPosition);
    }
}
