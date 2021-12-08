using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,0.5f); //0.5s后爆炸特效小消失
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
