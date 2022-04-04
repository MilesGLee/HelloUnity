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
    [SerializeField] private GameObject storyHUD;
    [SerializeField] private Text storyText;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject HUD;
    [SerializeField] private Text HUDText;

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
        HUD.SetActive(false);
        HUDText.text = "";
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playerStory == 6)
            {
                if (hasGrapple == true)
                    playerStory++;
            }
            else
            {
                playerStory++;
            }
        }
        storyUI();
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, 5))
        {
            if (hit.transform.tag == "HERMES") 
            {
                HUD.SetActive(true);
                HUDText.text = "Press [E] to equip HERMES";
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    hasGrapple = true;
                    grappleObj.SetActive(true);
                }
            }
        }
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
            storyText.text = "Looks like your getting the hang of it. Great, move forward into the next room through the blue door.";
        if (playerStory == 4)
            storyText.text = "The object in the center of the room is the Core, your job will be to protect it from the cuboids. Were currently harvesting their planet for its resources and they are not happy about it.";
        if (playerStory == 5)
            storyText.text = "On the right side of the room you will find your main mode of transport and weaponry, the H.E.R.M.E.S utility tool. This piece of equipment can grapple with physics breaking force to specificly colored material.";
        if (playerStory == 6)
            storyText.text = "The material is shown in the direction the gun is pointing, go ahead and pick it up and try it out. Use [Left Mouse] to fire out a quick laser to take care of those pesky Cubids, and [Right Mouse] to grapple.";
        if (playerStory == 7)
            storyText.text = "Along with your H.E.R.M.E.S gear, you will have funds provided by the company to expend on utilities to protect the core. Killing Cuboids will increase your funds.";
        if (playerStory == 8)
            storyText.text = "Some of the purchasable machinery can be found on the left side of the room, these are automated turrets that will target Cuboids for you. You can buy and place them using [Tab]";
        if (playerStory == 9)
            storyText.text = "Well I believe thats everything, just try to keep that core at full health as long as you can. Proceed through the blue door whenever your ready to begin.";
        if (playerStory == 10)
            storyText.text = "Good luck.";
        if (playerStory == 11) 
        {
            storyHUD.SetActive(false);
        }
    }

    public void LockedState() 
    {
        grappleObj.SetActive(false);
        hasGrapple = false;
    }

    public void UnlockedState()
    {
        grappleObj.SetActive(true);
        hasGrapple = true;
    }
}
