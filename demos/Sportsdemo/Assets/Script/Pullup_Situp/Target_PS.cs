using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_PS : MonoBehaviour
{
    // Start is called before the first frame update
    float angle;
    float r = 1.32f;
    public GameObject center;
    Vector3 targetposition;
    float pi = Mathf.PI;
    void Start()
    {
        angle = Random.Range(-pi/2,pi/2);
        targetposition = new Vector3(center.transform.position.x + r * Mathf.Cos(angle),center.transform.position.y + r * Mathf.Sin(angle), center.transform.position.z);
        transform.position = targetposition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
