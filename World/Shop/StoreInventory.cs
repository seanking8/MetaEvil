using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreInventory : MonoBehaviour
{


    public GameObject inventory;

    private int allSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    public GameObject[] items;

    void Start()
          {

        allSlots = 14;
        slot = new GameObject[allSlots];
   
        //Read each slot to see if its empty
        for (int i = 0; i < allSlots; i++)
        {
        
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<StoreSlot>().item == null)
            {
                slot[i].GetComponent<StoreSlot>().empty = true;
            }
        }

        
           
    for(int i = 0; i < items.Length; i++)
        {
            ItemInfo info = items[i].GetComponent<ItemInfo>(); //See if i can combine potion and weapon.
            AddItem(items[i], info.name, info.type, info.icon, info.cost); //Adds item to inventory
     
        }


    }

    //Check for first empty slot and add item
    public void AddItem(GameObject itemObject, string itemID, string itemType, Sprite itemIcon,double value)
    {
        for (int i = 0; i < allSlots; i++)
        {
           
           
            if (slot[i].GetComponent<StoreSlot>().empty)
            {
                //Add item to slot

                slot[i].GetComponent<StoreSlot>().item = itemObject;
                slot[i].GetComponent<StoreSlot>().icon= itemIcon;
                slot[i].GetComponent<StoreSlot>().type = itemType;
                slot[i].GetComponent<StoreSlot>().ID = itemID;
                slot[i].GetComponent<StoreSlot>().value= value;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<StoreSlot>().UpdateSlot();
                slot[i].GetComponent<StoreSlot>().empty = false;

                return;
            }
        }
    
}

}
