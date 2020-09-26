using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Floor" || collision.tag == "Wall")
        {
          
            transform.parent.GetComponent<EnemyController>().Turn();//Whenever he gets stuck in an actor or farm then he turns around
      
        }

    }

}
