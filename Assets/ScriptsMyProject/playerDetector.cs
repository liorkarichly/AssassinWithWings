using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetector : MonoBehaviour
{

    //As the actor enters my field of vision I start firing
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.name == "Player")
        {

            transform.parent.GetComponent<EnemyController>().SetShootingState(true);

        }

    }

    //That the actor is out of my field of vision I stop firing
    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.name == "Player")
        {
        
            transform.parent.GetComponent<EnemyController>().SetShootingState(false);
        
        }

    }

}
