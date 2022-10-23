using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Text : MonoBehaviour
{
    // public string NpcNameText;
    // public string Text;
    [SerializeField]
    private TextMeshProUGUI NpcName;
    [SerializeField]
    private TextMeshProUGUI NpcText;
    public GameObject DialogBox;

    public float targetTimebase = 60.0f;
    float targetTime = 60.0f;
    bool Timer = false;
    // Start is called before the first frame update
    void Start()
    {
        targetTime = targetTimebase;
      DialogBox=  GameObject.Find("/Ui").transform.GetChild(4).gameObject;
        NpcName= GameObject.Find("/Ui").transform.GetChild(4).transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        NpcText = GameObject.Find("/Ui").transform.GetChild(4).transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            DialogBox.SetActive(false);
            targetTime = targetTimebase;//Resets timer
        }
    }

    public void UpdateText(string name, string text)//<--- not 100% when this will be called?
    {
        NpcName.SetText(name.ToString());
        NpcText.SetText(text.ToString());
        DialogBox.SetActive(true);
        Timer = true;

    }
    public void disableBox()
    {
        DialogBox.SetActive(false);
    }
}
