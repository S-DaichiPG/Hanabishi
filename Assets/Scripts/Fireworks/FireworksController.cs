using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksController : MonoBehaviour
{
    int score;
    GameObject GameDirector;
    public ParticleSystem fire_particle;
    // Start is called before the first frame update
    void Start()
    {
        //GameDirector = GameObject.Find("GameDirector").GetComponent<ScoreController>();
        GameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnParticleCollision(GameObject obj) 
    {
        Debug.Log(obj.gameObject.tag);

        if(obj.gameObject.tag == "enemy" || obj.gameObject.tag == "boss")
        {
            if(obj.gameObject.tag == "enemy")
            {  
                GameDirector.GetComponent<ScoreController>().updateScore();
            }
            fire_particle.Play();
            Destroy(this.gameObject,0.5f);
        }

    }
}

