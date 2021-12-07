using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 1.0f;

    public int value; // 价值 (1-5), 击杀此怪可以获得的加分

    public int hp; // 血量, 初始值为value

    // hp/value节点
    private Transform hpNode;

    private Transform game;

    // Start is called before the first frame update
    void Start()
    {
        // 节点名称
        this.name = "Monster";

        game = GameObject.Find("游戏主控").transform;

        // 怪物的价值：1-5之间，随机指定
        value = Random.Range(0, 5) + 1;
        hp = value;

        // 血条显示
        hpNode = transform.Find("hp/value");
        SetHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        transform.Translate(0, -dy, 0);

        // 怪物飞机屏幕下边界，则销毁该怪物
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // 设置图片显示
    public void SetSprite(Sprite sprite)
    {
        Transform animal = transform.Find("animal");
        SpriteRenderer renderer = animal.GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;

        // 头像的大小设为80px (宽度)
        float imgWidth = sprite.rect.width; // 图像的实际宽度
        float scale = 80 / imgWidth; // 缩放比例
        animal.localScale = new Vector3(scale, scale, scale);
    }

    // 更新HP显示
    public void SetHealth(int hpValue)
    {
        hpNode.localScale = new Vector3(hpValue / 5f, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.name.Equals("Bullet"))
        {
            // 被子弹击中，HP-1
            hp -= 1;
            // 更新HP显示
            SetHealth(hp);

            // HP降为0时，自动销毁此怪
            if(hp <= 0)
            {
                Destroy(this.gameObject);

                // 玩有得分 + this.value
                game.SendMessage("AddScore", this.value);
            }
        }
    }
}
