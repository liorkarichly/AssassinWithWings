using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRotate : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 180);//Rotate the bomb only in Transform Z
    }
}
