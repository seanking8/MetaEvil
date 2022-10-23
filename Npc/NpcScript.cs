using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{

    public Npc npc;
    public int npcHealth;
    public GameObject gameManger;
    private PlayerStats playerStats;
    public new Healthbar healthbar;
    private Animator anim;
    public int scaledHealth;
    NPC_Text text;
    public GameObject Endscreen;
    public bool isendboss;
    int coins;
    public AudioSource hurtSound;
    public AudioSource deathSound;
    public AudioSource victorySound;

    // Start is called before the first frame update
    void Awake()
    {
       // gameManger = GameObject.Find("/GameManger");
        scaledHealth = npc.npcLevel * 20;//Scales npc health based on level
        npcHealth = scaledHealth;

        try
        {
            text = this.GetComponent<NPC_Text>();
        }
        catch (Exception e)
        { }//Not boss npc

        playerStats = gameManger.GetComponent<PlayerStats>();

        coins = npc.coinDrop;
        anim = GetComponent<Animator>();
        healthbar.SetMaxHealth(npcHealth);
    }
    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(npcHealth);
        if (npcHealth <= 0)//Kills npc
        {
            deathSound.Play();
            anim.SetTrigger("DeathTr");
        }
    }

    public void Kill()
    {
        PlayerStats.addxp(npc.npcExp);
        GameObject loot;
        try
        {
            text.disableBox();
        }
        catch (Exception e) { }
        if (isendboss == true)
        {
            victorySound.Play();
            Endscreen.SetActive(true);
        }
        playerStats.increasepoints(coins);
        gameObject.SetActive(false);
    }

    public void PlayHurtSound()
    {
        hurtSound.Play();
    }
}
