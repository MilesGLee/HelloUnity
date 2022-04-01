using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public int worldStory = 0;
    [SerializeField] private PlayerManager _pm;
    [SerializeField] private GameObject Wall1;
    [SerializeField] private GameObject Wall2;
    [SerializeField] private GameObject Obj1;
    public Transform check;

    void Start()
    {

    }

    void Update()
    {
        WorldStory();
    }

    void WorldStory()
    {
        if (_pm.playerStory == 3)
        {
            worldStory = 1;
            Wall1.SetActive(false);
        }
        if (_pm.hasGrapple == true && Obj1.active == true)
        {
            Obj1.SetActive(false);
        }
        if (_pm.playerStory == 11)
        {
            worldStory = 2;
            Wall2.SetActive(false);
        }
    }
}
