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
        InvokeRepeating("CreateDanJia", 0.1f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateDanJia()
    {
        float x = Random.Range(-2, 2);
        float y = 5;
        GameObject  DanJia = Instantiate(DanJiaPrefab);
        DanJia.transform.position = new Vector3(x, y, 0);        
    }
}
