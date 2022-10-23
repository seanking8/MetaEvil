using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DialogueManager : MonoBehaviour
{
    public string[] StandardDialog;
    public string[] Dialog2;
    // public float targetTimebase = 60.0f;
    // float targetTime = 60.0f;
    NPC_Text text;
    public string NpcName;
    // bool remembers = false;
    // bool timerStarted = false;
    public Transform player;
    private Animator anim;
    public float range = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // targetTime = targetTimebase;
        text = this.GetComponent<NPC_Text>();
        
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= range)
        {
            anim.SetBool("IsTalking", true);
            Speak();
        }
        else
        {
            anim.SetBool("IsTalking", false);
        }
        
    }
    public void Speak()
    {
        text.UpdateText(NpcName, StandardDialog[0]);
    }
}
