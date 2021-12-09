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
    public GameObject EndText;
    int degreesPersecond = 80;  //初始速度
    int addspeed = 10;   //加速度
    int score = 0;  //得分
    Vector3 rotatedtc = Vector3.back;  //旋转方向
    bool RotateDic = true;  //判断旋转方向
    bool ifontarget;    //判断空格键是否在目标处按下
    float angle;    //目标生成角度
    float pi = Mathf.PI;
    float r = 1.31f;
    
    void Start()
    {
        
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
                EndText.SetActive(true);
                degreesPersecond = 0;
                Invoke("ExitGame",3f);
            }

    }
    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsScore++;
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
