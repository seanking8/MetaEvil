using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public int playerLevel = 1;
    public int maxHealth = 0;
    public float maxStamina = 0;
    public Text stats;
     void Start()
    {
        maxHealth = PlayerStats.maxHealth;
        maxStamina = PlayerStats.maxStamina;
        playerLevel = PlayerStats.playerLevel;
    }
    void Update()
    {
        //Update levels
        maxHealth = PlayerStats.maxHealth;
        maxStamina = PlayerStats.maxStamina;
        playerLevel = PlayerStats.playerLevel;
        //Update text
        stats.text = playerLevel + "\n " + maxHealth + "\n " + maxStamina;
    }
}
