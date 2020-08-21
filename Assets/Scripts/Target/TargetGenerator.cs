using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{   
    // 移動方向の制御
    public int key;
    public GameObject targetPrefab;

    //スパン
    float span = 1.0f;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject target = Instantiate(targetPrefab) as GameObject;
            int px = Random.Range(0, 20);
            target.transform.position = new Vector3(-35, 0, px);
        }

    }
     
}
