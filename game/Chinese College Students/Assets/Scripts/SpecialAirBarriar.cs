using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAirBarriar : MonoBehaviour
{
    // Start is called before the first frame update
    //用来控制特殊空气墙显形的脚本

    private SpriteRenderer sr;
    public Sprite[] wallSprite; //0存放的是可以看见的屏障 1.纯黑背景图
    void Start()
    {
        
    }

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeVisible()
    {   
        Invoke("changeInvisible",5f);
        sr.sprite = wallSprite[0];       
    }

    private void changeInvisible()
    {
        sr.sprite = wallSprite[1];
    }
}
