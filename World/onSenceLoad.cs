using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onSenceLoad : MonoBehaviour
{

    public GameObject Weapon1;
    public PlayerStats stats;
    Inventory inv;
    public GameObject Inventory;
     public NPC_Text text;
    public GameObject LoadingScreen;
    void Start()
    {
        try {

            AudioListener.volume = SaveBetweenScenes.volume;
            Debug.Log(SaveBetweenScenes.volume);
            if (SceneManager.GetActiveScene().name == "player") //Scene 1
            {

                string choice = SaveBetweenScenes.choiceSave;
                inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();



                if (choice == "choice1")
                {
                    Choice1();
                    text.UpdateText("Hard", "Hard?? Why would you choose hard?? What are you trying to prove? Who are you trying to impress ? because I'm certainly not! I was already scared to walk a little over there and now the monsters hit even harder because you decided to wake up and be arrogant today! You better walk the walk buddy. * Ahem * I'll be the guide now");

                }
                else if (choice == "choice2")
                {
                    Choice2();
                    text.UpdateText("Med", "Hm, normal, you're not very unique, are you? Wouldn't want to make things too exciting now, would we ? That would be too much fun.Let's get this over with.");
                }
                else if (choice == "choice3")
                {
                    text.UpdateText("Easy", "Wow, easy? Seriously? Why would we need you now? I could go out there myself and save the world at this rate. * sighs * Fine I'll do my job now.");
                    Choice3();
                }
            }
            else
            {

            }

        }catch(Exception e) {
            Debug.Log("Issue in secne loading "+e);
        }//Game at times trys to run these while scenes arent fully moved over
        }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (SceneManager.GetActiveScene().name == "Area2" && stats.gethealth() > 0)
            {
                GameObject.Find("Ui/DeathScreen").SetActive(false);
                GameObject.Find("Ui/LoadingScreen").SetActive(false);
            }
        }catch(Exception e)
        {
            //Object not yet loaded
        }
        
    }
    void Choice1()
    {
        //Doesnt instantly update


        // inv.AddItem(Weapon1, Weapon1.name, Weapon1.GetComponent<ItemInfo>().type, Weapon1.GetComponent<ItemInfo>().icon); //Adds item to inventory
        
            stats.setstats(50, 50f);
        
      
       

    }
    void Choice2()
    {
        //Doesnt instantly update
      
     //   inv.AddItem(Weapon1, Weapon1.name, Weapon1.GetComponent<ItemInfo>().type, Weapon1.GetComponent<ItemInfo>().icon); //Adds item to inventory
        stats.setstats(100, 120f);
    }
    void Choice3()
    {
        //Doesnt instantly update
       
      //  inv.AddItem(Weapon1, Weapon1.name, Weapon1.GetComponent<ItemInfo>().type, Weapon1.GetComponent<ItemInfo>().icon); //Adds item to inventory
        stats.setstats(150, 200f);
    }

}
