using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    
    //用来装饰初始化地图所需物体的数组
    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙 7.生命增加的额外奖励 8.暂停所有敌人的额外奖励 9.炸弹 10.大型敌人 11.小型敌人
    //墙可以被破坏，障碍不能被破坏
    public float bonusTimeVal = 0;
    public GameObject Explosion;
    public GameObject[] item; 
    private List<Vector3> itemPositionList = new List<Vector3>();//用于存放已经有东西的位置
    public List<GameObject> EnemyList1; //用于存放敌人的列表
    private void Update() 
    {   
        //15s钟随机生成bonus
        bonusTimeVal+=Time.deltaTime;
        if (bonusTimeVal>=15)
        {            
            CreateBonus();
            bonusTimeVal = 0;
        }

        if (Bonus_Bomb.isBombActive)
        {
            destroyAllEnemy();
            Bonus_Bomb.isBombActive = false;
           
        }
    }

    private void Awake() 
    {
        InitMap();
    }

    private void InitMap()
    {
        //实例化基地
        CreateItem(item[0],new Vector3(0,-8,0),Quaternion.identity);
        //实例化墙（可破坏）来围住基地
        CreateItem(item[1],new Vector3(-1,-8,0),Quaternion.identity);
        CreateItem(item[1],new Vector3(1,-8,0),Quaternion.identity);
        CreateItem(item[1],new Vector3(-1,-7,0),Quaternion.identity);
        CreateItem(item[1],new Vector3(0,-7,0),Quaternion.identity);
        CreateItem(item[1],new Vector3(1,-7,0),Quaternion.identity);

        //实例化Bonus
        CreateBonus();

        //实例化空气墙
        for (int i = -11; i < 12; i++)//实例化最上面一行和最下面一行空气墙
        {
            CreateItem(item[6],new Vector3(i,9,0),Quaternion.identity);
            CreateItem(item[6],new Vector3(i,-9,0),Quaternion.identity);
        }

        for (int i = -8; i < 9; i++) //实例化左右两边的空气墙
        {
            CreateItem(item[6],new Vector3(-11,i,0),Quaternion.identity);
            CreateItem(item[6],new Vector3(11,i,0),Quaternion.identity);
        }
        
        //实例化地图其他物体
        for (int i = 0; i < 60; i++)//实例化墙
        {
            CreateItem(item[1],CreateRamdpmPosition(),Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)//实例化障碍
        {
            CreateItem(item[2],CreateRamdpmPosition(),Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)//实例化河流
        {
            CreateItem(item[4],CreateRamdpmPosition(),Quaternion.identity);
        }
        for (int i = 0; i < 30; i++)//实例化草
        {
            CreateItem(item[5],CreateRamdpmPosition(),Quaternion.identity);
        }
        // for (int i = 0; i < 20; i++)
        // {
        //     //CreateItem(item[1],CreateRamdpmPosition(),Quaternion.identity);
        //     CreateItem(item[2],CreateRamdpmPosition(),Quaternion.identity);
        //     //CreateItem(item[3],CreateRamdpmPosition(),Quaternion.identity);
        //     CreateItem(item[4],CreateRamdpmPosition(),Quaternion.identity);
        //     CreateItem(item[5],CreateRamdpmPosition(),Quaternion.identity);
            
        // }

        //初始化玩家
        GameObject go = Instantiate(item[3],new Vector3(-2,-8,0),Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;

        //产生敌人
        EnemyList1.Add(Instantiate(item[10],new Vector3(-10,8,0),Quaternion.identity));     
        EnemyList1.Add(Instantiate(item[10],new Vector3(0,8,0),Quaternion.identity));
        EnemyList1.Add(Instantiate(item[10],new Vector3(10,8,0),Quaternion.identity));   
        // CreateItem(item[3],new Vector3(0,8,0),Quaternion.identity);
        // CreateItem(item[3],new Vector3(10,8,0),Quaternion.identity);
        InvokeRepeating("CreateEnemy",4,4);//设定一定的时间间隔重复产生敌人

    }
    //封装的实例化函数，作用是实例化物体后将其父物体设置为MapCreation。使程序更美观
    private void CreateItem(GameObject createGameObject,Vector3 createPosition,Quaternion createRotation)
    {
        GameObject itemGo= Instantiate(createGameObject,createPosition,createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    //产生随机位置的方法
    private Vector3 CreateRamdpmPosition()
    {   
        //不生成x=-10,10的两列，y=-8，8这两行的位置
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9,10),Random.Range(-7,8),0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }            
        }
    }
    
    //用来判断这个位置列表中是否有这个位置，以防重复
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;               
            }
        }
        return false;
    }

    //产生敌人的方法
    private void CreateEnemy()
    {   
        


        int tempnum = Random.Range(0,2);
        if (tempnum==0)
        {
            int num = Random.Range(0,3);
            Vector3 EnemyPos = new Vector3();
            if (num == 0)
            {
                EnemyPos = new Vector3(10,8,0);
            }
            else if (num == 1)
            {
                EnemyPos = new Vector3(0,8,0);
            }
            else
            {
                EnemyPos = new Vector3(10,8,0);
            }
            GameObject go = Instantiate(item[11],EnemyPos,Quaternion.identity);
            EnemyList1.Add(go);
        }
        else
        {   
            int num = Random.Range(0,3);
            Vector3 EnemyPos = new Vector3();
            if (num == 0)
            {
                EnemyPos = new Vector3(10,8,0);
            }
            else if (num == 1)
            {
                EnemyPos = new Vector3(0,8,0);
            }
            else
            {
                EnemyPos = new Vector3(10,8,0);
            }
            GameObject go = Instantiate(item[10],EnemyPos,Quaternion.identity);
            EnemyList1.Add(go);
            
        }
        //GameObject Enemygo =Instantiate(item[3],EnemyPos,Quaternion.identity);
        
        


    }

    private void CreateBonus()
    {   
        
        int num = Random.Range(7,10);
        Vector3 BonusPos = CreateRamdpmPosition();
        itemPositionList.Add(BonusPos);
        GameObject BonusItem = Instantiate(item[num],BonusPos,Quaternion.identity);
        GameObject.Destroy(BonusItem,Random.Range(15f,20f));
        // bonusTimeVal += Time.deltaTime;
        // if (bonusTimeVal >=15)
        // {
        //     Destroy(BonusItem);
        //     bonusTimeVal = 0;
        // }
        
    }
    private void destroyAllEnemy()
    {
        for (int i = 0; i < EnemyList1.Count; i++)
        {   
            PlayerMananger.Instance.playerScore = PlayerMananger.Instance.playerScore + 100;
            Instantiate(Explosion,EnemyList1[i].transform.localPosition,Quaternion.identity);
            Destroy(EnemyList1[i]);            
            
        }
        EnemyList1.Clear();
    }
}
