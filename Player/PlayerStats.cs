using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerStats : MonoBehaviour
{
    public static int playerLevel = 1;
    public static int playerXp = 0;
    
    public static int maxHealth = 100;
    public static float maxStamina = 100;
    public StaminaBar staminaBar;
    public static int currentHealth;
    public static float currentStanima;
    public Healthbar healthbar;
    private float StaminaRegenTimer = 1.0f;
    private const float StaminaDecreasePerFrame = 1.5f;
    private const float StaminaIncreasePerFrame = 5.0f;
    private const float StaminaTimeToRegen = 3.0f;
    public  int Points;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource impactSound;
    public AudioSource gameOverSound;
    GameObject shopMenu;
    
    public GameObject DeathScreen;
    public PlayerControler pcontroller;
    public float targetTime=5;
    [SerializeField]
    private TextMeshProUGUI currency;
     public bool setupdone;
    bool statsset;
    bool Playerisdead=false;
    private int x; //Random used in takedmg for player hurt sound.
    void Start()
    {
      //  currentHealth = 100;//When area 2 loads it takes a sec for the game to find them.
        setup();
        Points = 5; // <--- Only used in debug, Remember To set to 0
        currency.SetText(Points.ToString());
        DeathScreen = GameObject.Find("/Ui/DeathScreen");
    }
    public int gethealth()
    {
        return currentHealth;
    }
    public int  getlevel()
    {
        return playerLevel;
    }
    public void setup() {
        try
        {
            if (DeathScreen == null)
            {
                DeathScreen = GameObject.Find("/Ui/DeathScreen");
               
            }
            //   GameObject Ui = GameObject.Find("/Ui");
            //  DeathScreen.SetActive(false);
            if (healthbar || staminaBar == null)
            {
                healthbar = GameObject.Find("/Ui").transform.GetChild(0).GetComponent<Healthbar>();
                staminaBar = GameObject.Find("/Ui").transform.GetChild(1).GetComponent<StaminaBar>();
            }
            setupdone = true;
           
        }
        catch (Exception e) {
          
        }//Not yet loaded
    }
    public void takeDmg(int dmg) 
    {
     
        Debug.Log(dmg+" DMG "+currentHealth);
        

        impactSound.Play();

        x = Random.Range(1,10);
        
        if(x > 5)
        {
            hurtSound1.Play();
        }else 
        {
            hurtSound2.Play();
        }
        
        currentHealth -= dmg;
    }


    public  void increaseLevel()
    {
        playerLevel += 1;
        playerXp = 0;//Resets xp level

        maxHealth += 20;
        maxStamina += 20;

        healthbar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStam(maxStamina);
        healthbar.SetHealth(maxHealth);//Level up heals
        staminaBar.SetStam(maxStamina);
    }

    public void increaseHealth(int health)
    {
        int newhealth = currentHealth + health;
        Debug.Log(newhealth);
        if (newhealth <= maxHealth)
        {
        
            currentHealth += health;
        }
    }
    public void increasepoints(int points)//Adds points
    {
        Points+= points;
        currency.SetText(Points.ToString());
    }
    public bool decreasepoints(int points)// Removes points
    {
      
        if (points <= Points)
        {
            Points-= points;
            currency.SetText(Points.ToString());
            return true;
        }
        else
        {
            return false;
        }
      

    }
    public  void setstats(int health,float stamina)
    {
        
            maxHealth = health;
            maxStamina = stamina;
            currentHealth = health;
            currentStanima = stamina;
        staminaBar.SetStam(stamina);
        staminaBar.SetMaxStam(maxStamina);
       
        healthbar.SetHealth(health);
        healthbar.SetMaxHealth(maxHealth);
        healthbar.slider.value = health;

        statsset = true;

        Debug.Log("Set stats "+health);
      
       

    }
    public static void addxp(int xp)
    {

        playerXp += xp;

    }
    public static bool playerhasStanima()//if player has stanima
    {
        if (currentStanima != 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private void nextlevelcheck()
    {

        if (playerXp >= 100 * playerLevel)//If player has 500 xp + the level multi
        {
            increaseLevel();
        }

    }
    void Update()
    {
        if (setupdone == false)
        {
            setup();
        }
        if (currentHealth <=4 || DeathScreen.activeInHierarchy == true)
        {
            gameOverSound.Play();
        }
        if (currentHealth <= 0) //Seting stats can be a tad slow.
        {
            
           // Playerisdead = true;
            DeathScreen.SetActive(true);
            Debug.Log(Death_Manager.Deaths + " Value");
            if (Playerisdead == false) //Unless you want 1000+ deaths
            {
                Playerisdead = true;
                Death_Manager.Deaths=Death_Manager.Deaths+1;
                Debug.Log(Death_Manager.Deaths+" Added Death");
            }
         
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                Cursor.lockState = CursorLockMode.Confined; //Sets it so cursor can be used only in game
                Cursor.visible = true;//Sets coursor visable
                SceneManager.LoadSceneAsync("mainmenu", LoadSceneMode.Single);

            }
        }
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        healthbar.SetHealth(currentHealth);//Due to static call this has to be done
        if (isRunning == true)//Player is running
        {
            currentStanima = Mathf.Clamp(currentStanima - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, maxStamina);
            StaminaRegenTimer = 0.0f;
            staminaBar.SetStam(currentStanima);
        }
        else if (currentStanima < maxStamina)//if player isnt running
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
            {
                currentStanima = Mathf.Clamp(currentStanima + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, maxStamina);
                staminaBar.SetStam(currentStanima);
            }
            else
            {
                StaminaRegenTimer += Time.deltaTime;
                staminaBar.SetStam(currentStanima);
            }
        }
        healthbar.SetHealth(currentHealth);//Sets new health
                                           //Debug.Log(currentHealth);
        /*   if (currentHealth == 0)
           {

               DeathScreen.SetActive(true);
               targetTime -= Time.deltaTime;
               if (targetTime <= 0.0f)
               {
                   Application.LoadLevel(Application.loadedLevel);

               }

           }*/
        nextlevelcheck();
        //  Debug.Log(playerXp+" Xp");

        //Debug stuff
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            increaseLevel();
        }
    }

}
