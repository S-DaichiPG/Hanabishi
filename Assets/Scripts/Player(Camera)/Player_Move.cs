using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 player_pos;
    public float add_speed = 50f; 
    float moveX=0f, moveZ=0f;

    void Clamp()
    {
        player_pos = transform.position; //プレイヤーの位置を取得

        player_pos.x = Mathf.Clamp(player_pos.x, -260, 275); //x位置が常に範囲内か監視
        player_pos.z = Mathf.Clamp(player_pos.x, -310, 275);
        transform.position = new Vector3(player_pos.x, player_pos.y,player_pos.z); //範囲内であれば常にその位置がそのまま入る
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
            //float x =  Input.GetAxis("Horizontal") * add_speed;
            //float z = Input.GetAxis("Vertical") * add_speed;
            //Vector3 direction = new Vector3(moveX , 0, moveZ);

        // Time.timeScale == 0でゲーム停止
        if (Time.timeScale == 1.0f)
        {

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
            // if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
            // {
            //     rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            // }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
           // Clamp();
        }
        // if (sceneChange.boss && vs_boss == false)
        // {
        //     vs_boss = true;
        //     bossEnemy = GameObject.Find("BossEnemy").GetComponent<BossEnemy_BossEnemy>();
        //     boss = GameObject.Find("BossEnemy").gameObject;
        // }
    }
    void FixedUpdate()
    {
        // if(Input.GetKey(KeyCode.A))
        // {
        //     rb.velocity = new Vector3(-10f,0f,0f);
        // }
        // if(Input.GetKey(KeyCode.D))
        // {
        //     rb.velocity = new Vector3(10f,0f,0f);
        // }
        // if(Input.GetKey(KeyCode.W))
        // {
        //     rb.velocity = new Vector3(0f,0f,10f);
        // }
        // if(Input.GetKey(KeyCode.S))
        // {
        //     rb.velocity = new Vector3(0f,0f,-10f);
        // }
         //キー入力による値を代入(解説は後で
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.velocity =  transform.forward * z * add_speed + transform.right * x * add_speed;

        //↑で代入された値をVector3型のIdouHoukouという変数に代入する

        //rbに力を加える
        //velocityは質量などの物理演算を無視するときに使う

        //rbの回転をさせない様にする
        //rb.constraints = RigidbodyConstraints.FreezeRotation;


        // float z = Input.GetAxis("Vertical") * add_speed;
        // rb.velocity = new Vector3(x, 0, z);
    }

}
