using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public GameObject monsterPrefab;

    public Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        // CreateMonster();
        // 反射机制
        InvokeRepeating("CreateMonster", 0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMonster()
    {
        float x = Random.Range(-2, 2);
        float y = 5;
        GameObject monster = Instantiate(monsterPrefab);
        monster.transform.position = new Vector3(x, y, 0);

        // 随机选择一个头像
        int index = Random.Range(0, images.Length);
        Sprite sprite = this.images[index];
        monster.SendMessage("SetSprite", sprite);        
    }
}
