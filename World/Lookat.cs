using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{

    public GameObject target;//Use spell target (inside player)

    void Update()
    {
        this.transform.LookAt(target.transform);
    }
  
}
