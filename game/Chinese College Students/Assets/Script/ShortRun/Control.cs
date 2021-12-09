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
    int flag;
    int count = 20;
    void Start()
    {
        flag = Random.Range(0,2);
        Debug.Log(flag);
    }

    // Update is called once per frame
    void Update()
    {
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
        if(count == 0)
        {
            flag = -1;
            left.SetActive(false);
            right.SetActive(false);
            Debug.Log("GameOver");
            Invoke("ExitGame",3f);
        }
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");
        GlobalControl.Instance.SportsScore++;
    }
}
