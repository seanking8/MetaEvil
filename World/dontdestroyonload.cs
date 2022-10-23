using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonload : MonoBehaviour
{
    void Start()
    {      DontDestroyOnLoad(this.gameObject);
    }
}
