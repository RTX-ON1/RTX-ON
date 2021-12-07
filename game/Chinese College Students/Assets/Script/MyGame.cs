using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using  static MyJet;

public class MyGame : MonoBehaviour
{
    public int score = 0;
    public float fillTime;

    public Text timeText;
    private float gameTime=60; 
    private bool gameOver;
    public GameObject gameOverPanel;
    public Text finalScoreText;

    Transform ui;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        //
        ui = GameObject.Find("Canvas").transform;

        ClearScore();

    }

    // Update is called once per frame
    void Update()
    {
        gameTime-=Time.deltaTime;
        if(MyJet.isdestory)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = score.ToString();
            gameOver = true;

        }
        if (gameTime<=0)
        {
            gameTime = 0;
            //显示我们的失败面板
            //播放失败面板的动画
            gameOverPanel.SetActive(true);
            finalScoreText.text = score.ToString();
            gameOver = true;
        }
        timeText.text=gameTime.ToString("0");

    }

    public void ClearScore()
    {
        this.score = 0;

        // 以0作为消息参数时，必须使用3参数形式
        ui.SendMessage("UpdateScore",0, SendMessageOptions.RequireReceiver);
    }

    // 击杀怪物后得分
    public void AddScore(int score)
    {
        if (gameOver)
        {
            return;
        }
        this.score += score;
        ui.SendMessage("UpdateScore", this.score);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
