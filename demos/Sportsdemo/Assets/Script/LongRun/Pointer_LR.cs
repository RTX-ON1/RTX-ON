using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer_LR : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startpos;
    public GameObject center;
    public int degreesPersecond = 45;
    public static float score = 0.0f;
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
        score += Time.deltaTime;
    }
}
