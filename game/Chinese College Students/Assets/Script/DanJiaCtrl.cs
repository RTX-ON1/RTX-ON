using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanJiaCtrl : MonoBehaviour
{
    public GameObject DanJiaPrefab;

    

    // Start is called before the first frame update
    void Start()
    {
        
        // 反射机制
        InvokeRepeating("CreateDanJia", 5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateDanJia()
    {
        if(GameObject.Find("游戏主控").GetComponent<MyGame>().gameOver){
            return;
        }
        float x = Random.Range(-2, 2);
        float y = 5;
        GameObject DanJia = Instantiate(DanJiaPrefab);
        DanJia.transform.position = new Vector3(x, y, 0);        
    }
}
