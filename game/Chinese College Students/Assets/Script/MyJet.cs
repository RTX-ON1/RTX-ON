using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class MyJet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 2.5f;

    private float interval = 0.4f;
    private float count = 0;
    public static bool isdestory;

    // Start is called before the first frame update
    void Start()
    {
        isdestory=false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 定时逻辑
        count += Time.deltaTime;
        if (count >= interval)
        {
            count = 0;
            Fire();
        }

        // 按键响应
        float step = moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(step, 0, 0);
        }
    }

    private void Fire()
    {
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.name.Equals("Monster"))
        {isdestory=true;}
    }

}
