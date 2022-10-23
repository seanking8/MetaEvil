using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store: MonoBehaviour
{

    public GameObject inventory;
    public GameObject Player;
    PlayerControler playerControler;
    bool openShop = false;
    public GameObject boss;
     void Start()
    {
        playerControler = Player.GetComponent<PlayerControler>();
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && boss.active == false)
        {
            openShop = !openShop;
        }
        
    }
    void Update()
    {
        //Will be moved to open affter level done
       // if (Input.GetKeyDown(KeyCode.K))
      //  {
      //      openShop = !openShop;
      //  }

        if (openShop == true)
        {
            inventory.SetActive(true);    //Inventory is visable
            playerControler.editmove(false);
            Cursor.lockState = CursorLockMode.Confined; //Sets it so cursor can be used only in game
            Cursor.visible = true;//Sets coursor visable
        }
        else if (openShop == false)
        {
            playerControler.editmove(true);
            inventory.SetActive(false);
            Cursor.visible = false;//Sets coursor invisable
        }
    }
    public void closeShop()
    {
        openShop = !openShop;
    }

}
