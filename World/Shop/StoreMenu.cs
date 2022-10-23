using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    private GameObject ItemStore;
    public GameObject PlayerStats;
     PlayerStats pstats;
     Inventory inv;
    void Start()
    {
        pstats = PlayerStats.GetComponent<PlayerStats>();
        inv= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void BuyItem()
    {
        ItemStore = GameObject.FindGameObjectWithTag("ItemStoreage");//Gets where item is storaged
        
        try {
            GameObject item = ItemStore.transform.GetChild(0).gameObject;
            double cost = item.GetComponent<ItemInfo>().cost;
            //Debug.Log("Type " + item.GetComponent<Iteminfo>().type);
           
            if (pstats.decreasepoints((int)cost)==true){
              
                try
                {
                    if (item.GetComponent<ItemInfo>().type.Equals("buff"))//Checks if item is a buff
                    {
                       // Debug.Log("Hit");
                 
                        //Change player stats
                        return;
                    }
                    
                }
                catch (Exception e)
                {
                    
                    Debug.Log(e.Message);
                    ItemInfo info = item.GetComponent<ItemInfo>();
                    Debug.Log("Issue " + info.name);
                }
                ItemInfo iteminfo = item.GetComponent<ItemInfo>();
                inv.AddItem(item, iteminfo.name, iteminfo.type,iteminfo.icon); //Adds item to inventory
            }
        }
        catch(Exception e)
        {

            e.GetBaseException();
        }
       
    }
}
