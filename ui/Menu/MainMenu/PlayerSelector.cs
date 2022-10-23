using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerChoiceStats choice1;
    public PlayerChoiceStats choice2;
    public PlayerChoiceStats choice3;
    [SerializeField]
    private TextMeshProUGUI Health;
    [SerializeField]
    private TextMeshProUGUI Stanima;
    [SerializeField]
    private TextMeshProUGUI Weapon;
    [SerializeField]
    private TextMeshProUGUI dmg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void option1()
    {
        Health.SetText(choice1.health.ToString());
             Stanima.SetText(choice1.stanima.ToString());
             //   Weapon.SetText(choice1.weapean.name.ToString());
             //       dmg.SetText(choice1.item_Data.value.ToString());
                         SaveBetweenScenes.choiceSave = "choice1";
                            
    }
    public void option2()
    {
        Health.SetText(choice2.health.ToString());
        Stanima.SetText(choice2.stanima.ToString());
      //  Weapon.SetText(choice2.weapean.name.ToString());
      //  dmg.SetText(choice2.item_Data.value.ToString());
        SaveBetweenScenes.choiceSave = "choice2";
    }
    public void option3()
    {
        Health.SetText(choice3.health.ToString());
        Stanima.SetText(choice3.stanima.ToString());
     //   Weapon.SetText(choice3.weapean.name.ToString());
     //   dmg.SetText(choice3.item_Data.value.ToString());
        SaveBetweenScenes.choiceSave = "choice3";
    }
    public void start()
    {
        SceneManager.LoadScene("player");
    }
}
