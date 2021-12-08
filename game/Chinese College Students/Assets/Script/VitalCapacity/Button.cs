using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    int score = 0;
    int addscore;
    float deltatime;    //检测时间间隔
    float timerate = 0.05f;
    float gameTime = 10;
    void Start()
    {
        deltatime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        
        //游戏结束条件
        if(gameTime<=0)
        {
            gameTime = 0;
            Debug.Log("GameOver");
            deltatime = 9999;
            Invoke("ExitGame",3f);
        }

        if(Time.time >= deltatime)
        {
            if(Input.GetKey("space"))
            {
                addscore = Random.Range(0,50);
                score = score + addscore;
                deltatime += timerate;
            }
            
        }

        scoreText.text = ""+score;
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");

    }
}
