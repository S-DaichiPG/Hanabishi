using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultControll : MonoBehaviour
{
    GameObject scoreText;
    int result_score;
 

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score");
        result_score = ScoreController.getScore();
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.GetComponent<Text>().text = "Your score：" + this.result_score.ToString();

        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
