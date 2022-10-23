using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Stats", menuName = "Stats")]
public class PlayerChoiceStats : ScriptableObject
{
    public  GameObject weapean;
    public Item_data item_Data;
    public int health;
    public float stanima;
    public Vector3 PickupPostion;//For putting in player hands
    public Vector3 PickupRotation;

}
