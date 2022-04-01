using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    public Toggle MobileToggle;

    void Start()
    {
        
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
