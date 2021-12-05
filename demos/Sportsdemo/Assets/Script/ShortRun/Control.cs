using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject left;
    public GameObject right;
    public Text leftcount;
    int flag;
    int count = 100;
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
    }
}
