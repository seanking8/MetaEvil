using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

//This script goes on every slot in the inventory


public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public string ID;
    public string type;
    public bool empty;
    public Transform slotIconGO;
    public Sprite icon;
    public GameObject hand;
    public bool equiped;
    bool setupdone;
    PlayerStats playerStats;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        try
        {
            if (equiped == true)
            {//unequips item
               // item.SetActive(false);
                equiped = false;
                GameObject iteminhand = hand.transform.GetChild(0).gameObject;
                iteminhand.transform.SetParent(null, false);
             
            }
            else
            {
                UseItem();
            }
          
        }
        catch { }//Slot is blank
        
    }

    void Start()
    {
        try
        {
            hand = GameObject.FindGameObjectWithTag("Hand");//Players hand Due to how scene loads this may need to be run multi times.
            playerStats = GameObject.Find("/GameManger").GetComponent<PlayerStats>();//Player stats
        }
        catch(Exception e)
        {
            //Object not loaded yet
        }
      
    }
    public void setup()
    {
        try
        {
            hand = GameObject.FindGameObjectWithTag("Hand");//Players hand Due to how scene loads this may need to be run multi times.
            playerStats = GameObject.Find("/GameManger").GetComponent<PlayerStats>();//Player stats
         //   setupdone = true;
        }
        catch (Exception e)
        {
            //Object not loaded yet
        }
    }
    void Update()
    {
        if (hand==null||playerStats==null) //Due to bug with script attempting to load from old scene before its removed this exists.
        {
            setup();
        }
    }

    public void UpdateSlot()
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
      
        if (type == "weapon")
        {
            //Need unequip
            equiped = true;
            item.SetActive(true);
             GameObject dupeitem= GameObject.Instantiate(item);
            dupeitem.transform.SetParent(hand.transform, true);//Sets as child of Temphand
            dupeitem.transform.localPosition = item.GetComponent<ItemInfo>().PickupPostion;//Sets Postion
            dupeitem.transform.localEulerAngles = item.GetComponent<ItemInfo>().PickupRotation;//Sets Rotation
           // item.SetActive(true);//Sets active
            dupeitem.gameObject.tag = "Untagged";//Removes tag
            item.SetActive(false);
        }
        else if (type=="potion")
        { 
            playerStats.increaseHealth(item.GetComponent<ItemInfo>().value); //Increase Player health
            DestroyObject(item);//Removes potion
            this.transform.GetChild(0).GetComponent<Image>().sprite = null;
            this.GetComponent<Slot>().empty = true;
        }

    }
  

}
