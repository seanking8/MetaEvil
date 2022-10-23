using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRange : MonoBehaviour
{
    //Script built to handle intract with shop, Can expand to add interact with others.
    Transform target;   // Reference to the player
    // Start is called before the first frame update
    public int range;
    public GameObject ShopInteract;
    public GameObject Shop;
    public bool talks;
    public bool interactenabled;
    PlayerControler playerControler;
    public bool setupdone;
    void Start()
    {
        playerControler = GameObject.Find("/Player").GetComponent<PlayerControler>();
        target = PlayerManager.instance.player.transform;
        setup();
    }
    public void setup()
    {
        try
        {
            GameObject ui = GameObject.Find("/Ui");
            ShopInteract = ui.transform.GetChild(7).gameObject;
            Shop= ui.transform.GetChild(3).gameObject;
            
        //    Debug.Log(Shop.name);
            setupdone = true;
        }
        catch (Exception e)
        {

            //Object not found Is inventory loaded?
        }
    }
    // Update is called once per frame
    void Update()//This will only be a issue if there is more then 1 per scene. IF need more throw a bool or something on for active like inventory.
    {
        if (setupdone == false)
        {
            setup();
           
           
        }
       ShopInteract.SetActive(false);
       Shop.SetActive(false);
        float distance = Vector3.Distance(target.position, transform.position);//Tracks player distance

        if (distance <= range)
        {
            if (talks == true)
            {
                //Call on boss dialog. not 100% sure how to set out the remember here.
            }
            ShopInteract.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                interactenabled = !interactenabled;
            }
                if (interactenabled==true)
                {
                Shop.SetActive(true);//Create a on/off
                ShopInteract.SetActive(false);
                playerControler.editmove(false);
                    Cursor.lockState = CursorLockMode.Confined; //Sets it so cursor can be used only in game
                    Cursor.visible = true;//Sets coursor visable
              }
            else
            {
                Shop.SetActive(false);//Create a on/off
                playerControler.editmove(true);
                Cursor.lockState = CursorLockMode.Locked; //Sets it so cursor can be used only in game
                Cursor.visible = false;//Sets coursor invisable
            }
               
            
        }
        else
        {
            ShopInteract.SetActive(false);
        }

    }
}
