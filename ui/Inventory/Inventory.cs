using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script goes onto the player


public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
     public GameObject inventory;
    
    private int allSlots;   
    private GameObject[] slot;

    public GameObject slotHolder;

    public AudioSource itemPickup;
    PlayerControler playerControler;
    bool setupdone=false;
    void Start()
    {
        if (slotHolder || inventory == null) {
            setup();
        }
        else
        {
            setupdone = true;
        }


        
        allSlots = 25;
        slot = new GameObject[allSlots];
        playerControler = this.GetComponent<PlayerControler>();
        try
        {
            for (int i = 0; i < allSlots; i++)
            {
                slot[i] = slotHolder.transform.GetChild(i).gameObject;

                if (slot[i].GetComponent<Slot>().item == null)
                {
                    slot[i].GetComponent<Slot>().empty = true;
                }
            }
        }catch(Exception e) { }
      
        
    }
    public void setup()
    {
        try
        {
            slotHolder = GameObject.Find("/Ui/Inventory/Slot Holder");
            inventory = GameObject.Find("/Ui/Inventory");
            inventory.SetActive(false);
            allSlots = 25;
            slot = new GameObject[allSlots];
            playerControler = this.GetComponent<PlayerControler>();
            //Read each slot to see if its empty
            for (int i = 0; i < allSlots; i++)
            {
                slot[i] = slotHolder.transform.GetChild(i).gameObject;

                if (slot[i].GetComponent<Slot>().item == null)
                {
                    slot[i].GetComponent<Slot>().empty = true;
                }
            }
            setupdone = true;
        }catch(Exception e)
        {
            //Object not found Is inventory loaded?
        }
    }

    void Update()
    {
        if (setupdone == false) //Due to bug with script attempting to load from old scene before its removed this exists.
        {
            setup();
            return;
        }
        //Tab key opens/closes inventory

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);    //Inventory is visable
            playerControler.editmove(false);
            Cursor.lockState = CursorLockMode.Confined; //Sets it so cursor can be used only in game
            Cursor.visible = true;//Sets coursor visable
        }
        else if(inventoryEnabled==false&& Input.GetKeyDown(KeyCode.Tab))
        {
             playerControler.editmove(true);
            inventory.SetActive(false);
            Cursor.visible = false;//Sets coursor invisable
        }
    }

    //If the player walks into an item, add item to inventory --- *All items which can be picked up must be tagged as Item*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickupable")
        {
            GameObject itemPickedUp = other.gameObject;
            ItemInfo item = itemPickedUp.GetComponent<ItemInfo>();
            AddItem(itemPickedUp, item.name, item.type, item.icon); //Adds item to inventory
            itemPickup.Play();
        }
    }

    //Check for first empty slot and add item
    public void AddItem(GameObject itemObject, string itemID, string itemType, Sprite itemIcon)
    {
        
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                //Add item to slot

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
               

                return;
            }
        }
    }
}
