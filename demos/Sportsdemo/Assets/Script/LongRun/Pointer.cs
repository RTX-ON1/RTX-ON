using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startpos;
    public GameObject center;
    public int degreesPersecond = 30;
    void Start()
    {
        // Debug.Log(degreesPersecond);
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey("space")){
            transform.RotateAround(center.transform.position, Vector3.back, degreesPersecond * Time.deltaTime);
        }
        else{
            if(transform.position != startpos){
                transform.RotateAround(center.transform.position, Vector3.forward, degreesPersecond * Time.deltaTime);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }
}
