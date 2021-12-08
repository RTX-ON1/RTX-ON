using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            return;
        }
        if (isDead)
        {
            Recover();
        }
        if (isWin)
        {
            isWinUI.SetActive(true);
            Invoke("ReturnToMenu",5);
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
            Invoke("ReturnToMenu",3);
            
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
        if (playerScore>=1000)
        {
            isWin = true;
        }
    }
    private void ReturnToMenu() //返回主界面
    {
        SceneManager.LoadScene(0);
    }
}
