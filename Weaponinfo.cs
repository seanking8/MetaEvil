using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponinfo : MonoBehaviour
{
    public  Weapon weapon;
    public  string weaponname;
    public  string type;
    public  int attackvalue;
    public  Sprite icon;
    public  bool equipped;
    public Vector3 PickupPostion;//For putting in player hands
    public Vector3 PickupRotation;
    public double cost;
    // public GameObject weapona;
    // Start is called before the first frame update
    void Start()
    {
        attackvalue = weapon.attackvalue; //Gets dmg from attacked scriptable object
        weaponname = weapon.weaponname;
        type = weapon.type;
        icon = weapon.icon;
        cost = weapon.cost;
        equipped = weapon.equipped;
        PickupPostion = weapon.PickupPostion;
        PickupRotation = weapon.PickupRotation;
    }
 

    }

