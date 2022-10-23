using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public bool pauseenabled;
    public GameObject Player;
    PlayerControler playerControler;
    bool setupdone;
    void Start()
    {
        setup();
    }
    public void setup()
    {
        pause = GameObject.Find("Pause");
        Player = GameObject.Find("Player");
        pause.SetActive(false);
        playerControler = Player.GetComponent<PlayerControler>();
        setupdone = true;
    }
    public void volumechange(float value)
    {
        SaveBetweenScenes.volume = value;
    }
    public void Quit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (setupdone == false)
        {
            setup();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Debug.Log("Esc pressed");
            pauseenabled = !pauseenabled;
        }

        if (pauseenabled == true)
        {
            pause.SetActive(true);
            playerControler.editmove(false);
            Cursor.lockState = CursorLockMode.Confined; //Sets it so cursor can be used only in game
            Cursor.visible = true;//Sets coursor visable
            Time.timeScale = 0;
        }
        else if (pauseenabled == false && Input.GetKeyDown(KeyCode.Escape))
        {
            AudioListener.volume = SaveBetweenScenes.volume;
            pause.SetActive(false);
            playerControler.editmove(true);
            Cursor.visible = false;//Sets coursor invisable
            Time.timeScale = 1;
        }
    }
        }

