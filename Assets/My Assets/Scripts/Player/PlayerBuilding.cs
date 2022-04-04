using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerBuilding : MonoBehaviour
{
    [SerializeField] private WorldManager _wm;
    [SerializeField] private PlayerMovement _pm;
    [SerializeField] private Text fundsText;
    [SerializeField] private GameObject TurretPrefab;
    [SerializeField] private GameObject buyMenu;
    private bool inMenu = false;
    private bool inBuilding = false;
    public int funds = 100;
    private GameObject currentBuilding;
    private Vector3 lookingPoint;
    [SerializeField] private LayerMask buildable;
    private Transform cam;
    private float buildDistance = 20;

    void Start()
    {
        cam = GetComponent<PlayerGun>().cam;
    }

    void Update()
    {
        fundsText.text = "" + funds;

        if (Input.GetKeyDown(KeyCode.Tab) && _wm.inPlay == true) 
        {
            inMenu = !inMenu;
            if (inMenu)
            {
                buyMenu.SetActive(true);
                _pm.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else 
            {
                buyMenu.SetActive(false);
                _pm.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && inBuilding) 
        {
            inBuilding = false;
            GetComponent<PlayerManager>().UnlockedState();
            inMenu = false;
            Destroy(currentBuilding);
        }
        if (inBuilding) 
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, buildDistance, buildable))
            {
                lookingPoint = hit.point;

                currentBuilding.transform.position = lookingPoint;

                if(currentBuilding.GetComponent<AutoTurretBehavior>)
            }
        }
    }

    public void BuyTurret() 
    {
        if (funds >= 100) 
        {
            GetComponent<PlayerManager>().LockedState();
            inBuilding = true;
            buyMenu.SetActive(false);
            _pm.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            currentBuilding = Instantiate(TurretPrefab, lookingPoint, Quaternion.identity);
        }
    }
}
