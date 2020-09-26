using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : ShootingCharacter
{

    //change component, if we want "play" with component
    public Animator anim;
    public Rigidbody2D rb;
    public float horizontalVelocity;// move 5 per sec
    
    private Vector2 jumpSpeed = new Vector2(0, 28f);// jump 
    private bool isGrounded = true;
    private Vector3 facingLeftScale = new Vector3(-1, 1, 1);
    private bool playerIsDead = false;
    public bool isLevelComplete = false;

    public AudioSource audioSource;//object 
    public AudioClip[] clip;//array of sound effect
   
    // Update is called once per frame
    void Update()
    {
        if (!(playerIsDead) && !(isLevelComplete))
        {

            float xVel = Input.GetAxis("Horizontal") * horizontalVelocity;
            float xInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xVel, rb.velocity.y);//rb.velocity.y-> We will not touch to leave the existing value

            if (xInput != 0)//turn on animation and control in left and right
            {

                anim.SetBool("Walk", true);
                if (xInput > 0)
                {

                    transform.localScale = Vector3.one;
                
                }
                else
                {

                    transform.localScale = facingLeftScale;

                }

            }
            else
            {

                anim.SetBool("Walk", false);
            
            }
            //getAxis - We will not touch to leave the existing value relevant for long presses like right and left

            if (Input.GetButtonDown("Jump") && isGrounded)
            {

                //ass y velocity
                rb.velocity += jumpSpeed;
            
            }

            if (Input.GetButtonDown("Fire1"))
            {

                ShootBullet(25);//What she gets is the speed of the bullet 

            }

        }

    }

    //checking if we on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "Floor")
                isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.transform.tag == "Floor")
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet" || collision.tag == "Traps")//If a ball hits it
        {

            playerIsDead = true;
            anim.SetTrigger("Die");//Turns on the animation
            Destroy(gameObject, 1);//Accepts the object and the delay
            Invoke("ReloadScene", 6);
            
            //Turn on sound effects
           if(collision.tag == "Bullet")
            {

                audioSource.PlayOneShot(clip[1]);
            
            }
           else 
           if(collision.tag == "Traps") 
            {

                audioSource.PlayOneShot(clip[2]);
            
            }
        
        } 
        else 
        if(collision.tag == "Win")
        {

            audioSource.PlayOneShot(clip[0]);
            isLevelComplete = true;
            rb.velocity = Vector2.zero;
            Invoke("ReloadScene", 5);
        
        }

    }

}
