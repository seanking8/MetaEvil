using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public Item_data item;
    public string name;
    public  string type; //Weapon,Potion
    public  int value; //Attack or potion value
    public  Sprite icon;
    //Uneeded for potions
    public  bool equipped;
    public Vector3 PickupPostion;//For putting in player hands
    public Vector3 PickupRotation;

    public float cost;//Cost of item for shop
    void Start()
    {
        value = item.value; //Loads
        name = item.Itemname;
        type = item.type;
        icon = item.icon;
        cost = item.cost;
        equipped = item.equipped;
        PickupPostion = item.PickupPostion;
        PickupRotation = item.PickupRotation;
    }


}



