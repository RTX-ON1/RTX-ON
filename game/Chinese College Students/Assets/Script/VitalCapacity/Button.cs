using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public GameObject EndPanel;
    public Text EndText;
    int playerrank;
    int score = 0;
    int addscore;
    float deltatime;    //检测时间间隔
    float timerate = 0.05f;
    float gameTime = 10;
    void Start()
    {
        deltatime = Time.time;
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
    
        if(Time.time >= deltatime)
        {
            if(Input.GetKeyDown("space"))
            {
                addscore = Random.Range(60,80);
                score = score + addscore;
                deltatime += timerate;
            }
            //游戏结束条件           
            if(gameTime<=0)
            {
                gameTime = 0;
                Debug.Log("GameOver");
                deltatime += 9999;
                Rank(score);
                Invoke("ExitGame",3f);
            }
        }

        scoreText.text = ""+score;
    }

    private void Rank(int PlayerScore)
    {
        if(PlayerScore >= 4900 )
        {
            EndText.text = "你的得分为\nA\n您就是大肺王";
            EndPanel.SetActive(true);
            playerrank = 1;
        }
        else if(PlayerScore >= 4400)
        {
            EndText.text = "你的得分为\nB\n肺活量超人";
            EndPanel.SetActive(true);
            playerrank = 2;
        }
        else if(PlayerScore >= 3200)
        {
            EndText.text = "你的得分为\nC\n请勤加锻炼";
            EndPanel.SetActive(true);
            playerrank = 3;
        }
        else
        {
            EndText.text = "你的得分为\nD\n拜托，你很弱诶";
            EndPanel.SetActive(true);
            playerrank = 4;
        }
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsTime += 1;
        GlobalControl.Instance.SportsScore += GlobalControl.Instance.Cal_score(playerrank);

    }
}
