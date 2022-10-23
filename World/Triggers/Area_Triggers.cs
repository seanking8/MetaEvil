using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Triggers : MonoBehaviour
{
    public GameObject Npc;//for the npc its triggering text for
    public int bossstage;//0 = start of game and so on.
    public AudioSource BossMusic;
    public AudioSource Music;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Bosstage are " + bossstage + " Player " + Death_Manager.Boss_Stage);
            Npc.GetComponent<BossController>().isbossActive = true;
            //   text.UpdateText(NpcName,npcText); //<----This is only for vid
            //  if (bossstage != Death_Manager.Boss_Stage)//Checks if current stage is higher or lower then saved
            //  {

            // }
            if (Music.isPlaying == true)
            {
                BossMusic.Play();
                Music.Stop();
            }

            Npc.GetComponent<Boss_Dialog_Manager>().getstage(Death_Manager.Boss_Stage);
        }
    }
}
