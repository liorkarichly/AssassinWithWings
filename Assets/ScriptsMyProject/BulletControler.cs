using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{

    public Rigidbody2D rb;//Physical properties and that we can control the code
    public float lifeTime = 5.0f;//Lifespan of the bullet
   
    /// <summary>
    /// The flight of the bullet
    /// </summary>
    /// <param name="right"></param>
    public void SetSpeed(float xSpeed)
    {
        rb.velocity = new Vector2(xSpeed, 0);
    }
   
    // Start is called before the first frame update
    void Start()
    {
         
        Destroy(gameObject, lifeTime);//After a few seconds, destroy the bullet

    }

    /// <summary>
    /// Destroys the bullet after me that hits the enemy
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

    }

}
