using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    GameObject scoreText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score += 10;
        this.scoreText.GetComponent<Text>().text = "Score：" + score.ToString();
    }

    
    public static int getScore()
    {
 
		return score;
	}
}
