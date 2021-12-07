using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    int score = 0;
    int addscore;
    float deltatime;    //检测时间间隔
    float timerate = 0.05f;
    void Start()
    {
        deltatime = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
}
