using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{
    
    int score;
    GameObject GameDirector;

    void Start()
    {
        GameDirector = GameObject.Find("GameDirector");
    }

    //スコア更新
    void Update()
    {
         
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "target")
        {   
            GameDirector.GetComponent<ScoreController>().updateScore();
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject,0.5f);
    }




}
