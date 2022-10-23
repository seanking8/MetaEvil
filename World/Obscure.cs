using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obscure : MonoBehaviour
{
    Renderer rendr;
    void Start()
    {
        rendr = GetComponent<Renderer>();
        rendr.material.renderQueue = 3002; // set their renderQueue
    }
}
