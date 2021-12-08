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
    public Text lefttarget;
    int degreesPersecond = 45;
    float gameTime = 100;
    void Start()
    {
        // Debug.Log(degreesPersecond);
        startpos = transform.position;
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
            // gameoverpannel.SetActive(true);
            gameObject.SetActive(false);
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
        
        lefttarget.text = "" + Time.time.ToString("0");
    }

    private void OnTriggerStay(Collider other)
    {
        gameTime -= Time.deltaTime*2;
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Main Stage");

    }
}
