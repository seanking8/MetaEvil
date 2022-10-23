using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    public new string weaponname;
    public new string type;
    public new int attackvalue;
    public new Sprite icon;
    public new bool equipped;
    public Vector3 PickupPostion;//For putting in player hands
    public Vector3 PickupRotation;
    public float cost;//Cost of item for shop
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
