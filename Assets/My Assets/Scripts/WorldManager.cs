using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{
    [Header("World GameObjects")]
    [SerializeField] private GameObject tutorialWorld;
    [SerializeField] private GameObject world;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject spawned;
    [SerializeField] private Transform spawnerTarget;
    public GameObject player;
    [Header("UI")]
    [SerializeField] private GameObject playerGUI;
    [SerializeField] private GameObject playerGameover;
    [SerializeField] private Text worldTimeText;
    [SerializeField] private Text worldTimeMultiplierText;
    [SerializeField] private Text worldDifficultyMultiplierText;
    [SerializeField] private Text worldScoreText;
    [SerializeField] private Text finalScore;
    [SerializeField] private Text returnText;
    [Header("Variables")]
    public float worldTime = 0;
    public float spawnerTimer = 5f;
    public bool spawnerCooldown = false;
    private bool inPlay = false;
    public float playerScore = 0;
    public float difficultyMultiplier = 1;
    public bool gameOver = false;
    private int countdown = 5;

    void Start()
    {
        world.SetActive(false);
        tutorialWorld.SetActive(true);
        playerGUI.SetActive(false);
        playerGameover.SetActive(false);
        spawnerCooldown = true;
        if (PlayerPrefs.GetInt("Difficulty") == 0)
        {
            difficultyMultiplier = 1000;
            worldDifficultyMultiplierText.text = "Difficulty Bonus: (1x)";
        }
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            difficultyMultiplier = 100;
            worldDifficultyMultiplierText.text = "Difficulty Bonus: (2x)";
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            difficultyMultiplier = 10;
            worldDifficultyMultiplierText.text = "Difficulty Bonus: (3x)";
        }
        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            difficultyMultiplier = 1;
            worldDifficultyMultiplierText.text = "Difficulty Bonus: (10x)";
        }
    }

    void Update()
    {
        if (inPlay == true && gameOver == false)
        {
            worldTime += Time.deltaTime;
            worldTimeText.text = "" + Mathf.Round(worldTime * 100.0f) * 0.01f;
            worldTimeMultiplierText.text = "(x" + (Mathf.Round(worldTime) * 0.1f)/10 + ")";
            worldScoreText.text = "" + playerScore;
        }
        if (tutorialWorld.GetComponent<TutorialManager>().worldStory == 2 && tutorialWorld.active == true && Vector3.Distance(player.transform.position, tutorialWorld.GetComponent<TutorialManager>().check.position) < 2)
        {
            tutorialWorld.SetActive(false);
            world.SetActive(true);
            spawnerCooldown = false;
            spawnerTimer = 5f;
            inPlay = true;
            playerGUI.SetActive(true);
            StartCoroutine(startSpawn());
        }

        if (spawnerCooldown == false && gameOver == false)
            StartCoroutine(Spawner());
        spawnerTimer = 5 - worldTime / difficultyMultiplier;

        if (gameOver == true && inPlay == true) 
        {
            inPlay = false;
            player.GetComponent<PlayerManager>().enabled = false;
            playerGUI.SetActive(false);
            playerGameover.SetActive(true);
            float addition = playerScore * ((Mathf.Round(worldTime) * 0.1f) / 10);
            if (PlayerPrefs.GetInt("Difficulty") == 1)
                addition = addition * 2;
            if (PlayerPrefs.GetInt("Difficulty") == 2)
                addition = addition * 3;
            if (PlayerPrefs.GetInt("Difficulty") == 3)
                addition = addition * 10;
            playerScore += addition;
            finalScore.text = "" + playerScore;
            PlayerPrefs.SetFloat("BestScore", playerScore);
            InvokeRepeating("textCountDown", 0f, 1f);
        }
    }

    void textCountDown() 
    {
        returnText.text = "" + countdown;
        countdown--;
        if (countdown == 0) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Application.LoadLevel("main_menu");
        }
    }

    IEnumerator startSpawn() 
    {
        yield return new WaitForSeconds(5f);
        spawnerCooldown = false;
    }

    IEnumerator Spawner()
    {
        spawnerCooldown = true;
        yield return new WaitForSeconds(spawnerTimer);
        GameObject enemy = Instantiate(spawned, spawner.transform.position, spawner.transform.rotation);
        enemy.GetComponent<EnemyBehavior>().target = spawnerTarget;
        enemy.GetComponent<EnemyBehavior>().health = 1 + (int)worldTime / (int)difficultyMultiplier;
        enemy.GetComponent<EnemyBehavior>().damage = 1;
        enemy.GetComponent<EnemyBehavior>()._wm = this;
        enemy.GetComponent<EnemyBehavior>().GetComponent<NavMeshAgent>().speed = 10;
        spawnerCooldown = false;
        StopCoroutine(Spawner());
        StopAllCoroutines();
    }
}
