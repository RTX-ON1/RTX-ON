using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    // text
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("score").GetComponent<Text>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "" + score;

        Animation anim = scoreText.GetComponent<Animation>();
        anim.Play();
    }

}
