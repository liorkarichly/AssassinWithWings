using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if its toaching in something
        if (!GetComponent<BoxCollider2D>().IsTouchingLayers())
        {
         //turn the character
            transform.parent.GetComponent<EnemyController>().Turn();
        }
    }
}
