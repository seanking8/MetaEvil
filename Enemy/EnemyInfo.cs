using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
   // public Npc npc;
    public new string name;
    public new int Level;
    public new int attackvalue;
    public new int Health;
    public new int XpGain;
    public new Healthbar healthbar;
    public new GameObject[] Loot;
    public  EnemyInfo enemy;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)//Kills npc
        {
            PlayerStats.addxp(XpGain);
            Destroy(gameObject);
           
        }
        healthbar.SetHealth(Health);
        
    }
}
