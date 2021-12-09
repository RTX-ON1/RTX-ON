using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//global分数的修改在本脚本的DecideWin函数中。此脚本的分数修改改的是完整的一局坦克大战胜利或者失败的奖惩点数
//击杀敌人的奖惩点数卸载了同目录下enemy脚本的Die函数中
//基地爆炸的惩罚与生命值耗尽的惩罚写在了本脚本的Update函数中
//胜利的分数获取同样写在了本脚本的Update函数中
//到时候我会重新写一个score脚本，目前的代码管理稍有混乱

public class PlayerMananger : MonoBehaviour
{   
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public GameObject born;
    public bool isDefeat;
    public bool isWin;
    public Text playerScoreText;
    public Text playerLifeValueText; 
    public GameObject isDefeatUI;
    public GameObject isWinUI;

    //单例
    private static PlayerMananger instance;

    public static PlayerMananger Instance
    {
        get
        {
             return instance;
        }

        set
        {
            instance = value;
        }

    }

    private void Awake() 
    {
        Instance = this;     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        DecideWin();
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            GlobalControl.Instance.SocialScore -= 500;
            isDefeat = false;
            Invoke("ReturnToMenu",2);
            //ResetInterScore();           
            return;
        }
        if (isDead)
        {
            Recover();
        }
        if (isWin)
        {
            isWinUI.SetActive(true);
            GlobalControl.Instance.SocialScore += 1500;
            isWin = false;
            Invoke("ReturnToMenu",3);
            //ResetInterScore();
            return;
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString() ;
    }
    private void Recover()
    {
        if(lifeValue<=0)
        {
            //游戏失败，返回主界面
            isDefeat = true; 
                         
        }
        else
        {   
            isDead = false;
            lifeValue-=1;
            GameObject go = Instantiate(born,new Vector3(-2,-8,0),Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            
        }
    }
    private void DecideWin() //判断胜利的条件
    {
        if (playerScore>=1500)
        {
            isWin = true;                        
        }
    }
    private void ReturnToMenu() //返回主界面
    {
        SceneManager.LoadScene("Main Stage");
    }

    private void ResetInterScore() //重置内部的得分函数
    {
        playerScore = 0;
    }
}
