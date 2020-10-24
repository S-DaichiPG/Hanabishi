using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
     private Rigidbody rb;
     public float move_speed = 100f; 

     GameObject player;

    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody>();
         player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 回転スピード
        float rotate_speed = 10f;
        // ターゲット方向のベクトルを取得
        Vector3 targetpos = player.transform.position - this.transform.position;
        // 方向ベクトルを角度に変換
        Quaternion player_rotation = Quaternion.LookRotation(targetpos);
        // プレイヤーの方向を向く
        rb.rotation = Quaternion.Slerp(this.transform.rotation, player_rotation, rotate_speed);
        rb.velocity = transform.forward * move_speed;

    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Player_Status player_status = collision.gameObject.GetComponent<Player_Status>();
    //         if(damage - player_status.player_defence > 0){
    //             player_status.player_hp -= damage - player_status.player_defence;
    //         }
    //         DestoryObject();
    //     }else if(collision.gameObject.tag == "Asteroid"){
    //         DestoryObject();
    //     }
    //     if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
    //     {
    //         // 反発防止処理1
    //         rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    //     }
    // }
}
