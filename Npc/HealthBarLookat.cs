using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLookat : MonoBehaviour
{
 
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Player.transform);
        
    }
}
