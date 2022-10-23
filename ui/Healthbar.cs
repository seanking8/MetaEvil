using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{

    public Slider slider=null;
    public  void SetMaxHealth(int helath)
    {
        slider.maxValue = helath;
        slider.value = helath;
    }
    public void SetHealth(int health)
    {
    
        slider.value = health;
       
    }
     void Start()
    {
       
        if (this.gameObject.tag == "Npc")
        {
           
            slider.maxValue = this.GetComponent<NpcScript>().scaledHealth;
            slider.value = this.GetComponent<NpcScript>().npcHealth;
           
        }
    }
    void Update()
    {
        if (this.gameObject.tag == "Npc")
        {
          
            slider.value = this.GetComponent<NpcScript>().npcHealth;
        }
    }
}
