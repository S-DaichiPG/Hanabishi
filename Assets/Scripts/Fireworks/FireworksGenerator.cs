using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksGenerator : MonoBehaviour
{
    
    public GameObject fire_Prefab;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject firework = (GameObject)Instantiate(fire_Prefab, transform.position, transform.rotation);
             //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
            //Instantiate (firework, transform.position,transform.rotation);
            
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 worldDir = ray.direction;
            // firework.GetComponent<IgaguriController>().Shoot(
            //     worldDir.normalized*2000);

        }
    }
}