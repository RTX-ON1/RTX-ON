using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject left;
    public GameObject right;
    public Text leftcount;
    public GameObject EndPanel;
    public Text EndText;
    int flag;
    int playerrank;
    int count = 20;
    float playerTime;
    float deltatime;
    float timerate = 0.05f;
    void Start()
    {
        flag = Random.Range(0,2);
        // Debug.Log(flag);
        playerTime = 0;
        deltatime = Time.time;
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
    }

    // Update is called once per frame
    void Update()
    {
        playerTime += Time.deltaTime;
        if(flag == 0)
        {
            left.SetActive(true);
            right.SetActive(false);
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                left.SetActive(false);
                flag = Random.Range(0,2);
                count --;
            }
        }
        if(flag == 1)
        {
            left.SetActive(false);
            right.SetActive(true);
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                right.SetActive(false);
                flag = Random.Range(0,2);
                count --;
            } 
        }
        leftcount.text = "" + count;

        //游戏结束条件
        if(Time.time >= deltatime)
        {
          if(count <= 0)
            {
                flag = -1;
                left.SetActive(false);
                right.SetActive(false);
                deltatime += 99999;
                Debug.Log("GameOver");
                Debug.Log(playerTime);
                Rank(playerTime);
                Debug.Log(playerrank);
                Invoke("ExitGame",3f);
            }
            deltatime += timerate;
        }
        
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsTime += 1;
        GlobalControl.Instance.SportsScore += GlobalControl.Instance.Cal_score(playerrank);

    }

    private void Rank(float playerTime)
    {
        if(playerTime < 6)
        {
            EndText.text = "你的得分为\nA\n你跑的也忒快了";
            EndPanel.SetActive(true);
            playerrank = 1;
        }
        else if(playerTime < 7)
        {
            EndText.text = "你的得分为\nB\n请继续努力";
            EndPanel.SetActive(true);
            playerrank = 2;
        }
        else if(playerTime < 9)
        {
            EndText.text = "你的得分为\nC\n还可以更快一点";
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
}
