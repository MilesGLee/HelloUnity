using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialWorld;
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject playerGUI;
    [SerializeField] private GameObject spawned;
    [SerializeField] private Text worldTimeText;
    [SerializeField] private Transform target;
    public GameObject player;
    public float worldTime = 0;
    public float timer = 5f;
    public bool cooldown = false;
    private bool inPlay = false;

    void Start()
    {
        world.SetActive(false);
        tutorialWorld.SetActive(true);
        playerGUI.SetActive(false);
        cooldown = true;
    }

    void Update()
    {
        if (inPlay == true)
        {
            worldTime += Time.deltaTime;
            worldTimeText.text = "" + worldTime;
        }
        if (tutorialWorld.GetComponent<TutorialManager>().worldStory == 2 && tutorialWorld.active == true && Vector3.Distance(player.transform.position, tutorialWorld.GetComponent<TutorialManager>().check.position) < 2)
        {
            tutorialWorld.SetActive(false);
            world.SetActive(true);
            cooldown = false;
            timer = 5f;
            inPlay = true;
            playerGUI.SetActive(true);
            StartCoroutine(startSpawn());
        }

        if (cooldown == false)
            StartCoroutine(Spawner());
        timer = 5 - worldTime / 100;
    }

    IEnumerator startSpawn() 
    {
        yield return new WaitForSeconds(5f);
        cooldown = false;
    }

    IEnumerator Spawner()
    {
        cooldown = true;
        yield return new WaitForSeconds(timer);
        GameObject enemy = Instantiate(spawned, transform.position, transform.rotation);
        enemy.GetComponent<EnemyBehavior>().target = target;
        enemy.GetComponent<EnemyBehavior>().health = 1 + (int)worldTime / 100;
        enemy.GetComponent<EnemyBehavior>().damage = 1;
        enemy.GetComponent<EnemyBehavior>().GetComponent<NavMeshAgent>().speed = 10;
        cooldown = false;
        StopCoroutine(Spawner());
        StopAllCoroutines();
    }
}
