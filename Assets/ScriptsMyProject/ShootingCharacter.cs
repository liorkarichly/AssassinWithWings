using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCharacter : MonoBehaviour
{

    //So that the player will contain the bullet
    public GameObject bulletPF;//
    public GameObject bulletSpawnPoint;
    private GameObject bulletInstance;

    public void ShootBullet(int xSpeed)
    {

        bulletInstance = Instantiate(bulletPF, bulletSpawnPoint.transform.position, Quaternion.identity);
        bool facingRight = transform.localScale.x > 0;
        
        if (facingRight)
        {

            bulletInstance.GetComponent<BulletControler>().SetSpeed(xSpeed);
        
        }
        else
        {

            bulletInstance.GetComponent<BulletControler>().SetSpeed(-(xSpeed));
     
        }

    }

}
