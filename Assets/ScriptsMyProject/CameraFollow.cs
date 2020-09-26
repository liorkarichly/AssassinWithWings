using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Follow Camera about player

    public GameObject player;//reference to player
    private Vector3 newPos = new Vector3();// Location of the player
    private float cameraZPos = -10f;// Location Camera in Z

    // Update is called once per frame
    void FixedUpdate()//For the camera to move more smoothly
    {
        
        newPos.x = player.transform.position.x;
        newPos.y = player.transform.position.y;
        if (newPos.y < 0)// The camera can't to down below to ground 
        {

            newPos.y = 0;

        }

        //without the if... // newPos.y = Mathf.Clamp(newPos,MinDown,MaxUp);
        // its the position of camera the max up
        //term to level
        newPos.z = cameraZPos;
        transform.position = newPos;
        //transform.position = Vector3.Lerp(transform.position,newPos,Time.deltaTime);// lerp זה סוג של אינטפרציה שאנחנו אומרים לו לזוז בהגרדתיות והוא מקבל מאיזה ווקטור לאיזה ווקטור ואיזה אחוז להזיז
        
    }

}
