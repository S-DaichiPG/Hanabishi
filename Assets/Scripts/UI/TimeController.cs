using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeController : MonoBehaviour
{
    GameObject timerText;
    float time = 120.0f;
    
    void Start()
    {
        this.timerText = GameObject.Find("Time");
    }

    
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = "Time：" + this.time.ToString("F1");

         if(time<0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
