using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Dialog_Manager : MonoBehaviour
{
    public string[] StandardDialog;
    public string[] Dialog2;
    public int bossstage;
    public float targetTimebase = 60.0f;
    float targetTime = 60.0f;
    NPC_Text text;
    public string NpcName;
    bool remembers=false;
    bool timerStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        targetTime = targetTimebase;
        text = this.GetComponent<NPC_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted == true)
        {
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                if (remembers == true)
                {
                    text.UpdateText(NpcName, Dialog2[Random.Range(1, Dialog2.Length)]);
                }
                else
                {
                    text.UpdateText(NpcName, StandardDialog[Random.Range(1, Dialog2.Length)]);
                }
                targetTime = targetTimebase;//Resets timer
            }
        }
        //Needs timer, And to randomly put out dialog
    }
    public void getstage(int stage)
    {
         //  Debug.Log("Stage " + stage);
        if(stage== bossstage)
        {
            timerStarted = true;
            remembers = true;
            text.UpdateText(NpcName, Dialog2[0]);
        }
        else
        {
            text.UpdateText(NpcName, StandardDialog[0]);
            Death_Manager.Boss_Stage = bossstage;// Boss will remember next time
        }
 
        // save stage get new dialong set
    }
}
