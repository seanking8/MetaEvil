using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public float targetTime= 5;
    [SerializeField]
    private TextMeshProUGUI Deaths;
    // Start is called before the first frame update
    void Start()
    {
        Deaths.SetText(Death_Manager.Deaths.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            SceneManager.LoadSceneAsync("mainmenu", LoadSceneMode.Single);
        }
        }
}
