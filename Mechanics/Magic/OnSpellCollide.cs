using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpellCollide : MonoBehaviour
{
    private PlayerStats playerStats;
    public GameObject gameManger;
    public int spelldmg;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameManger.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        try
        {
          
            if (other.gameObject.tag == "Player")
            {
             //   Debug.Log("Player hit");
                playerStats.takeDmg(spelldmg);
            }
            DestroyObject(gameObject);
        }
        catch (Exception e)
        {
            DestroyObject(gameObject);
        }
    
    }
}
