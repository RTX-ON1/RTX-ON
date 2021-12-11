using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyJet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 2.5f;

    private float interval = 0.4f;
    private float count = 0;
    public static bool isdestory;
    public static bool havenDanJia;
    public static bool havennDanJia;
    public static bool havennnDanJia;
    public static bool havennnnDanJia;


    // Start is called before the first frame update
    void Start()
    {
        havenDanJia=false;
        havennDanJia=false;
        havennnDanJia=false;
        havennnnDanJia=false;
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
        if(GameObject.Find("游戏主控").GetComponent<MyGame>().gameOver){
            return;
        }

        // 按键响应
        float step = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x<-2){
            return;
        }
            transform.Translate(-step, 0, 0); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x>2){
            return;
        }
            transform.Translate(step, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.y>4.5){
            return;
        }
            transform.Translate(0, step, 0); 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(transform.position.y<-4.5){
            return;
        }
            transform.Translate(0, -step, 0); 
        }

    }

    private void Fire()
    {
        if(GameObject.Find("游戏主控").GetComponent<MyGame>().gameOver){
            return;
        }
        
        if(havennnnDanJia){
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Vector3 pos1 = transform.position + new Vector3(0.5f, 1f, 0);
        GameObject bullet1 = Instantiate(bulletPrefab, pos1, transform.rotation);
        Vector3 pos2 = transform.position + new Vector3(-0.5f, 1f, 0);
        GameObject bullet2 = Instantiate(bulletPrefab, pos2, transform.rotation);
        Vector3 pos3 = transform.position + new Vector3(1f, 1f, 0);
        GameObject bullet3 = Instantiate(bulletPrefab, pos3, transform.rotation);
        Vector3 pos4 = transform.position + new Vector3(-1f, 1f, 0);
        GameObject bullet4 = Instantiate(bulletPrefab, pos4, transform.rotation);
        
        }
        else if(havennnDanJia){
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Vector3 pos1 = transform.position + new Vector3(0.5f, 1f, 0);
        GameObject bullet1 = Instantiate(bulletPrefab, pos1, transform.rotation);
        Vector3 pos2 = transform.position + new Vector3(-0.5f, 1f, 0);
        GameObject bullet2 = Instantiate(bulletPrefab, pos2, transform.rotation);
        Vector3 pos3 = transform.position + new Vector3(1f, 1f, 0);
        GameObject bullet3 = Instantiate(bulletPrefab, pos3, transform.rotation);
        }
        else if(havennDanJia){
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Vector3 pos1 = transform.position + new Vector3(0.5f, 1f, 0);
        GameObject bullet1 = Instantiate(bulletPrefab, pos1, transform.rotation);
        Vector3 pos2 = transform.position + new Vector3(-0.5f, 1f, 0);
        GameObject bullet2 = Instantiate(bulletPrefab, pos2, transform.rotation);
        }
        else if(havenDanJia){
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Vector3 pos1 = transform.position + new Vector3(0.5f, 1f, 0);
        GameObject bullet1 = Instantiate(bulletPrefab, pos1, transform.rotation);
        }
        else{
        Vector3 pos = transform.position + new Vector3(0, 1f, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.name.Equals("Monster"))
        {isdestory=true;}
        if( collision.name.Equals("DanJia"))
        {
            if(havennnDanJia){
                havennnnDanJia=true;
            }
            else if(havennDanJia){
                havennnDanJia=true;
            }
            else if(havenDanJia){
                havennDanJia=true;
            }
            else{
                havenDanJia=true;
            }
            Destroy(collision.gameObject);
        }
    }

}
