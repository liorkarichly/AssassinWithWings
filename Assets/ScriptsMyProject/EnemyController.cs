using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShootingCharacter
{

    private float xSpeed = 4;//speed enemy
    private bool shootingState = false;//For the shot, Nati that the enemy would encounter the player he shot
    public bool patrollingEnemy;//Is he just going and when does he start firing
    public Animator anim;
    private bool isDead = false;
  
    // Start is called before the first frame update
    void Start()
    {

        if (patrollingEnemy )
        {

            anim.SetBool("Patroling", true);
        
        }
        else
        {
        
            anim.SetBool("Patroling", false);
        
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (patrollingEnemy && !shootingState && !isDead)
        {

            transform.Translate(xSpeed * Time.deltaTime, 0, 0);
            //Time.deltaTime= Units per second of the movement of the player (the enemy)  
        
        }

    }

    public void Turn()
    {

        transform.localScale = new Vector3(-transform.localScale.x, 2, 2);
        xSpeed = -xSpeed;
   
    }

    public void SetShootingState(bool state)//Collision with player and start of shooting
    {

        shootingState = state;
       
        //True - We'll stop the Patroling
        if (shootingState)
        {

            anim.SetBool("Patroling", false);
            Shoot();
        
        }
        else
        {
            if (patrollingEnemy)
            {
            
                anim.SetBool("Patroling", true);
            
            }

        }

    }

    private void Shoot()
    {
        
        if (shootingState && !isDead)
        {

            ShootBullet(15);//Speed of the bullet
            anim.SetTrigger("Shoot");//Turns on the animation of the shot
            //invoke()- A mechanism that activates a function in Delay, and it runs a function in Delay
            Invoke("Shoot", 2);//Calls to herself
        }

    }

    //Handling a case that collides with a projectile enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Bullet")//If a ball hits it
        {

            isDead = true;
            anim.SetTrigger("Die");//Turns on the animation
            Destroy(gameObject, 1);//Accepts the object and the delay

        }


    }
}
