using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
   public float radius =3f;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;//Area it can have interaction
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
