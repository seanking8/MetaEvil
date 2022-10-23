using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public new string name;
    public new int Level;
    public new int attackvalue;
    public new int Health;
    public new int xpGain;
    public new int coinDrop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
