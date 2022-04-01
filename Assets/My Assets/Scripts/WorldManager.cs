using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWorld;
    [SerializeField] private GameObject World;
    public GameObject Player;

    void Start()
    {
        World.SetActive(false);
        tutorialWorld.SetActive(true);
    }

    void Update()
    {
        if (tutorialWorld.GetComponent<TutorialManager>().worldStory == 2 && tutorialWorld.active == true && Vector3.Distance(Player.transform.position, tutorialWorld.GetComponent<TutorialManager>().check.position) < 2)
        {
            tutorialWorld.SetActive(false);
            World.SetActive(true);
        }
    }
}
