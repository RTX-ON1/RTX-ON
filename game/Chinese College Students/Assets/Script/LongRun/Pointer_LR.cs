using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pointer_LR : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startpos;
    public GameObject center;
    public GameObject EndPanel;
    public Text EndText;
    public Text lefttarget;
    int degreesPersecond = 45;
    int playerrank;
    float gameTime = 30;
    float keepTime = 0;
    void Start()
    {
        // Debug.Log(degreesPersecond);
        startpos = transform.position;
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
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
            gameObject.SetActive(false);
            Rank(keepTime);
            Invoke("ExitGame",3f);
        }
       
        if( Input.GetKey("space")){
            transform.RotateAround(center.transform.position, Vector3.back, degreesPersecond * Time.deltaTime);
        }
        else{
            if(transform.position != startpos){
                transform.RotateAround(center.transform.position, Vector3.forward, degreesPersecond * Time.deltaTime);
            }
        }
        
        lefttarget.text = "" + keepTime.ToString("0");
    }

    private void Rank(float playerTime)
    {
        if(playerTime > 22)
        {
            EndText.text = "你的得分为\nA\n你跑的也忒快了";
            EndPanel.SetActive(true);
            playerrank = 1;
        }
        else if(playerTime > 20)
        {
            EndText.text = "你的得分为\nB\n请继续努力";
            EndPanel.SetActive(true);
            playerrank = 2;
        }
        else if(playerTime > 18)
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

    private void OnTriggerStay(Collider other)
    {
        keepTime += Time.deltaTime;
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsTime += 1;
        GlobalControl.Instance.SportsScore += GlobalControl.Instance.Cal_score(playerrank);

    }
}
