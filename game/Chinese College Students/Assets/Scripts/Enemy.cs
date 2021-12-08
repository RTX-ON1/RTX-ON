using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性值
    public static bool isStopEnemyBonusActive;  //控制敌方坦克是否被时停Bonus所停止
    public float moveSpeed = 3;  //控制坦克移动速度
    private Vector3  bulletEulerAngles;
    private float v = -1;
    private float h; 
    
    private bool isDefended = true;  //判断是否无敌,初始设定为无敌状态
    private float defendTimeVal = 3;  //用于玩家无敌时间的计时器，初始时间为3s

    //计时器
    private float timeValChangeDirection = 0; //控制敌人AI方向变化的计时器
    private float timeVal;  //控制子弹发射间隔

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
               
    }
    private void FixedUpdate() 
    {   
        move();
        moveSpeed = 3;
        if (isStopEnemyBonusActive)
        {               
            
            Invoke("move",5f);
            Invoke("ResetInvokeTime",5f);
            //SetInvokeTime();                                           
        }
        if (timeVal >=1f)
        {
            Attack();
        }
        else
        {
            timeVal+=Time.deltaTime;
        }
    }
    

    //坦克的攻击方法
    private void Attack()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
            if (isStopEnemyBonusActive)
            {
                return;
            }
            Instantiate(bulletPrefab,transform.position,Quaternion.Euler(transform.eulerAngles+bulletEulerAngles));
            timeVal = 0;
        //}


    }
    private void move() //坦克的移动方法
    {   
            if (isStopEnemyBonusActive)
            {
                return;
            }
            if (timeValChangeDirection>=4)
            {
            int num = Random.Range(0,8);
            if (num>5)//控制敌人AI向下移动
            {
                v = -1;
                h = 0;
            }
            else if(num==0) //往回走
            {
                v = 1;
                h = 0;
            }
            else if (num>0 && num <=2)//向左走
            {
                h =-1;
                v = 0;
            }
            else if (num>=3 && num <=4)
            {
                h = 1;
                v = 0;
            }
            timeValChangeDirection = 0;
            }
            else
            {
                timeValChangeDirection +=Time.fixedDeltaTime;
            }
            //v = Input.GetAxisRaw("Vertical");
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

            //h = Input.GetAxisRaw("Horizontal");
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
        //产生一个爆炸的特效
        Instantiate(explosionPrefab,transform.position,transform.rotation);

        //死亡
        Destroy(gameObject);
        
        //玩家的得分加100
        PlayerMananger.Instance.playerScore += 100;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag =="Enemy")
        {
            timeValChangeDirection = 4;
            
        }
    }

    private void ResetInvokeTime()
    {
        isStopEnemyBonusActive = false;

    }

    
}
