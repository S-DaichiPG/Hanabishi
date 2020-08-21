using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TagetController : MonoBehaviour
{
   bool up_key = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        // 的を上下に移動させる
        moveUpDown();

        // 的を動かす
        transform.Translate(0.2f,0,0);

        if(transform.position.x > 37.0f)
        {
            Destroy(this.gameObject);
        }
    }



    void moveUpDown()
    {
        if(up_key == false)
        {
            if(this.gameObject.transform.position.y > -4.0f)
            {
                transform.Translate(0,-0.08f,0);
            }
            else  up_key = true;
            
        }
        

        if(up_key==true)
        {
            if(this.gameObject.transform.position.y < -0.3f)
            {
                transform.Translate(0,0.08f,0);
            }
            else  up_key = false;
        }
    }

        
}