using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool hasGrapple;
    [SerializeField] private GameObject grappleObj;
    [SerializeField] private GameObject mobileObj;
    public int playerStory;
    [SerializeField] private Text storyText;

    void Start()
    {
        playerStory = 0;
        hasGrapple = false;
        grappleObj.SetActive(false);
        if (PlayerPrefs.GetInt("Mobile") == 1)
        {
            mobileObj.SetActive(true);
            GetComponent<PlayerMovement>().usingMobile = true;
        }
        if (PlayerPrefs.GetInt("Mobile") == 0)
        {
            mobileObj.SetActive(false);
            GetComponent<PlayerMovement>().usingMobile = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            playerStory++;
        }
        storyUI();
    }

    void storyUI() 
    {
        if (playerStory == 0)
            storyText.text = "Welcome Cadet!";
        if (playerStory == 1)
            storyText.text = "To your first on site expedition. But first, were going to have to do some training.";
        if (playerStory == 2)
            storyText.text = "Use [WASD] to move around, and [Space] to jump.";
        if (playerStory == 3)
            storyText.text = "Looks like your getting the hang of it. Great, move forward into the next room.";
        if (playerStory == 4)
            storyText.text = "M";
    }
}
