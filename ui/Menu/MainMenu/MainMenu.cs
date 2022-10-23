using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject options;
    public GameObject play;
    public GameObject mainmenu;
    
    public Slider volume;
    public void Play()
    {
        play.SetActive(true);
        mainmenu.SetActive(false);
        
    }
    public void Options()
    {
        options.SetActive(true);
        mainmenu.SetActive(false);
    }
    public void goback()
    {
        options.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void changevol()
    {
        SaveBetweenScenes.volume = volume.value;
    }
}
