using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Start_btn;
    public GameObject Manual_btn;
    public GameObject Appreciate_btn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void OnStart()
    {
         SceneManager.LoadScene("GameScene");
    }

    public void OnManual()
    {

    }

    public void OnAppreciate()
    {
        
    }
}
