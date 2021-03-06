using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pointer_PS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject center;
    public GameObject target;
    public Text scoreText;
    public GameObject EndPannel;
    public Text EndText;
    int degreesPersecond = 80;  //初始速度
    int addspeed = 10;   //加速度
    int score = 0;  //得分
    Vector3 rotatedtc = Vector3.back;  //旋转方向
    bool RotateDic = true;  //判断旋转方向
    bool ifontarget;    //判断空格键是否在目标处按下
    float angle;    //目标生成角度
    float pi = Mathf.PI;
    float r = 1.31f;
    int playerrank;
    
    void Start()
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
    }

    // Update is called once per frame
    void Update()
    {
        if(RotateDic)
        {
            transform.RotateAround(center.transform.position, rotatedtc, degreesPersecond * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(center.transform.position, -rotatedtc, degreesPersecond * Time.deltaTime);
        }

        //游戏结束条件
        if(!ifontarget && Input.GetKeyDown("space"))
            {
                Rank(score);
                degreesPersecond = 0;
                Invoke("ExitGame",3f);
            }

    }

    private void Rank(int playerScore)
    {
        if(playerScore > 18)
        {
            EndText.text = "你的得分为\nA\n健身大神说的就是你";
            EndPannel.SetActive(true);
            playerrank = 1;
        }
        else if(playerScore > 16)
        {
            EndText.text = "你的得分为\nB\n超出常人的力量";
            EndPannel.SetActive(true);
            playerrank = 2;
        }
        else if(playerScore > 11)
        {
            EndText.text = "你的得分为\nC\n体质健硕";
            EndPannel.SetActive(true);
            playerrank = 3;
        }
        else
        {
            EndText.text = "你的得分为\nD\n拜托，你很弱诶";
            EndPannel.SetActive(true);
            playerrank = 4;
        }
    }
    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsTime += 1;
        GlobalControl.Instance.SportsScore += GlobalControl.Instance.Cal_score(playerrank);

    }
    private void OnTriggerStay(Collider other)
    {
        // Debug.Log("OnTriggerStay");
        ifontarget = true;
        if(Input.GetKey("space")){
            RotateDic = !RotateDic;
            degreesPersecond += addspeed;
            if(RotateDic)
            {
                angle = Random.Range(-pi/2,pi/2);
                target.transform.position = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
                score++;
            }
            else
            {
                angle = Random.Range(pi/2,3*pi/2);
                target.transform.position = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
                score++;
            }
        }
        scoreText.text = score.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        ifontarget = false;
    }

}
