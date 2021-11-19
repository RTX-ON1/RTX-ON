using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private float r = 1.32f;
    private float angle;
    public GameObject center;
    Vector3 targetposition;
    void Start()
    {
        // Debug.Log(r);
        angle = Random.Range(Mathf.PI,2*Mathf.PI);
        Debug.Log(angle);
        targetposition = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
        Debug.Log("targetposition:"+targetposition+"COS:"+Mathf.Cos(angle)+"SIN:"+Mathf.Sin(angle));
        transform.position = targetposition;
        // Debug.Log(transform.position);
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
