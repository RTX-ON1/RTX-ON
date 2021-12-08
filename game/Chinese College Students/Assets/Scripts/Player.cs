
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float moveSpeed = 3;  //控制坦克移动速度
    private Vector3  bulletEulerAngles;
    private float timeVal;  //控制子弹发射间隔
    private bool isDefended = true;  //判断是否无敌,初始设定为无敌状态
    private float defendTimeVal = 3;  //用于玩家无敌时间的计时器，初始时间为3s

    //引用
    private SpriteRenderer sr ;
    public Sprite[] tankSprite; //按照上右下左顺序
    public GameObject bulletPrefab; 
    public GameObject explosionPrefab; 
    public GameObject shieldPrefab;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {   //是否处于无敌状态
        if (isDefended == true)
        {   
            shieldPrefab.SetActive(true);
            defendTimeVal = defendTimeVal - Time.deltaTime;
            if (defendTimeVal<=0)
            {
                isDefended = false;
                shieldPrefab.SetActive(false);
            }
        }
        //攻击的cd
        if (timeVal>=0.4f)
        {
            Attack();
        }
        else
        {
            timeVal+=Time.deltaTime;
        }
    }
    private void FixedUpdate() 
    {   
        if (PlayerMananger.Instance.isDefeat == true)
        {
            return;
        }
        if (PlayerMananger.Instance.isWin == true)
        {
            return;
        }
        move();
        if (timeVal>=0.4f)
        {
            Attack();
        }
        else
        {
            timeVal+=Time.fixedDeltaTime;
        }
        
    }
    

    //坦克的攻击方法
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
            Instantiate(bulletPrefab,transform.position,Quaternion.Euler(transform.eulerAngles+bulletEulerAngles));
            timeVal = 0;
        }


    }
    private void move() //坦克的移动方法
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up*v*moveSpeed*Time.fixedDeltaTime,Space.World);//控制坦克的上下移动的图片
        if (v<0)  //V<0 往下
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles= new Vector3(0,0,-180);
        }
        else if (v>0)  // V>0 往上
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles= new Vector3(0,0,0);
        }
        
        if (v!= 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right*h*moveSpeed*Time.fixedDeltaTime,Space.World);//控制坦克左右移动的图片
        if (h<0)   //h<0 往左
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles= new Vector3(0,0,90);
        }
        else if (h>0)  // h>0 往右
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles= new Vector3(0,0,-90);
        }

    }
    
    //坦克的死亡方法
    private void Die() 
    {   
        if (isDefended)
        {
            return;
        }
        //玩家属性值管理
        //PlayerMananger.Instance.lifeValue-=1;
        PlayerMananger.Instance.isDead = true;
        //产生一个爆炸的特效
        Instantiate(explosionPrefab,transform.position,transform.rotation);

        //死亡
        Destroy(gameObject);
    }
        
    
}
