using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item_data", menuName = "Item_data")]
public class Item_data : ScriptableObject
{
    public  string Itemname; 
    public  string type; //Weapon,Potion
    public  int value; //Attack or potion value
    public  Sprite icon;
    //Uneeded for potions
    public  bool equipped;
    public Vector3 PickupPostion;//For putting in player hands
    public Vector3 PickupRotation;

    public float cost;//Cost of item for shop
    // Start is called before the first frame update

}

