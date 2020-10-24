using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RotateX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 void Update () {
        if (Time.timeScale == 1.0f) {
            float rotate_x = -Input.GetAxis ("Mouse Y"); // rotate_xをMouse Yの数値に
            Vector3 localeuler = transform.eulerAngles;
            localeuler.x += rotate_x;
            if(localeuler.x > 60 && localeuler.x < 180){
                localeuler.x = 60;
            }
            if(localeuler.x < 300 && localeuler.x > 180){
                localeuler.x = 300;
            }
            transform.eulerAngles = localeuler; // rotate_x,rotate_yの向きに回転
        }
    }
}
