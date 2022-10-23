using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageExit : MonoBehaviour
{
    public GameObject boss; //Boss for area
    public PlayerStats playerstats;
    public GameObject Inventory;
    public GameObject Player;
    bool run;
    GameObject shopinteract;
    GameObject shop ;
    public GameObject DeathScreen;
    public GameObject LoadingScreen;
    private void Start()
    {
        shopinteract = GameObject.Find("/Ui/shopInteract");
         shop = GameObject.Find("/Ui/Shop");
         DeathScreen = GameObject.Find("/Ui/DeathScreen");
         DeathScreen.SetActive(false);
    }
    void OnTriggerEnter(Collider other)

    {

        if (boss.active == false)
        {
            SaveBetweenScenes.level = playerstats.getlevel();
            if (run == false)
            {
                run = true;
              
                StartCoroutine(LoadYourAsyncScene());
            }

            // SceneManager.LoadScene("Area2");
        }

        IEnumerator LoadYourAsyncScene()
        {
            Inventory.transform.GetChild(2).gameObject.SetActive(true);
            shop.SetActive(true);
            shopinteract.SetActive(true);
            DeathScreen.SetActive(true);
            LoadingScreen.SetActive(true);
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            // The Application loads the Scene in the background at the same time as the current Scene.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Area2",LoadSceneMode.Additive);
            asyncLoad.allowSceneActivation = false;
            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                Debug.Log("Loading progress: " + (asyncLoad.progress * 100) + "%");
                if (asyncLoad.progress >= 0.9f)
                {
                    SceneManager.MoveGameObjectToScene(Inventory, SceneManager.GetSceneByName("Area2"));
                    asyncLoad.allowSceneActivation = true;
                }
                yield return null;
            }
           
            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene


            //  SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName("Area2"));
            // DestroyObject(Player);
            //  SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName("Area2"));
            // Unload the previous Scene
            // asyncLoad.allowSceneActivation = true;

            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
