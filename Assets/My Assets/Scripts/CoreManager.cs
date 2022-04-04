using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreManager : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMesh healthText;
    [SerializeField] private Color goodHealth;
    [SerializeField] private Color mediumHealth;
    [SerializeField] private Color badHealth;

    void Start()
    {
        health = 10;
    }

    void Update()
    {
        if (health == 0)
            healthText.text = "";
        if (health == 1)
            healthText.text = "|";
        if (health == 2)
            healthText.text = "||";
        if (health == 3)
            healthText.text = "|||";
        if (health == 4)
            healthText.text = "||||";
        if (health == 5)
            healthText.text = "|||||";
        if (health == 6)
            healthText.text = "||||||";
        if (health == 7)
            healthText.text = "|||||||";
        if (health == 8)
            healthText.text = "||||||||";
        if (health == 9)
            healthText.text = "|||||||||";
        if (health == 10)
            healthText.text = "||||||||||";
        if (health > 7)
            healthText.color = goodHealth;
        if (health < 7 && health > 4)
            healthText.color = mediumHealth;
        if (health < 4 && health > 0)
            healthText.color = badHealth;
    }

    public void TakeDamage(int amount) 
    {
        health = health - amount;
    }
}
