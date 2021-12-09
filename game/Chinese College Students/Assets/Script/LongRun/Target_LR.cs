using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_LR : MonoBehaviour
{
    // Start is called before the first frame update
    private float r = 1.32f;
    private float angle;
    public GameObject center;
    Vector3 targetposition;
    float nexttime = 5.0f;    //第一次变化时间
    float deltatime = 5.0f;   //变化时间间隔
    float pi = Mathf.PI;
    void Start()
    {
        angle = Random.Range(1.5f*pi,2*pi);
        // Debug.Log(angle);
        targetposition = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
        // Debug.Log("targetposition:"+targetposition+"COS:"+Mathf.Cos(angle)+"SIN:"+Mathf.Sin(angle));
        transform.position = targetposition;
    }

    // Update is called once per frame

    void Update()
    {
        // float s = Pointer_LR.score;
        // Debug.Log(s);
        // Debug.Log(Time.time);
        if(Time.time >= nexttime){
            angle = Random.Range(pi,1.5f*pi);
            targetposition = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
            // Debug.Log("angel:"+angle+"tragetposition:"+targetposition);
            transform.position = targetposition;
            nexttime += deltatime;
        }
    }
}
