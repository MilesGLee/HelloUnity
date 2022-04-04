using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] private Toggle MobileToggle;
    [SerializeField] private Dropdown difficulty;
    [SerializeField] private Text bestScore;

    void Start()
    {
        bestScore.text = "" + PlayerPrefs.GetFloat("BestScore");
    }

    void Update()
    {
        if (MobileToggle.isOn == true) 
        {
            PlayerPrefs.SetInt("Mobile", 1);
        }
        if (MobileToggle.isOn == false)
        {
            PlayerPrefs.SetInt("Mobile", 0);
        }
        if (difficulty.value == 0)
            PlayerPrefs.SetInt("Difficulty", 0);
        if (difficulty.value == 1)
            PlayerPrefs.SetInt("Difficulty", 1);
        if (difficulty.value == 2)
            PlayerPrefs.SetInt("Difficulty", 2);
        if (difficulty.value == 3)
            PlayerPrefs.SetInt("Difficulty", 3);
    }

    public void PlayGame() 
    {
        Application.LoadLevel("play_scene");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
