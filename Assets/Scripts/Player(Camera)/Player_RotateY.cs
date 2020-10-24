using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RotateY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if (Time.timeScale == 1.0f) {
            float rotate_y = Input.GetAxis ("Mouse X"); // rotate_yをMouse Xの数値に
            transform.Rotate (0, rotate_y, 0); // rotate_x,rotate_yの向きに回転
        }
    }
}
