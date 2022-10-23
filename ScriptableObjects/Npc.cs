using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Npc", menuName = "Npc")]
public class Npc : ScriptableObject
{
    public new string npcName;
    public new int npcAttack;
    public new string npcType;
    public new int npcLevel;
    public new int npcHealth;
    public new int npcExp;
    //  public new Healthbar healthbar;
    public new int coinDrop;

    // Start is called before the first frame update
    void Start()
    {
        //    healthbar.SetMaxHealth(npcHealth);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (npcHealth <= 0)//Kills npc
        {
            PlayerStats.addxp(npcExp);
          //  Destroy(gameObject);

        }
      //  healthbar.SetHealth(npcExp);
    }
}
