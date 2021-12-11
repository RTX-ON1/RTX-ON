using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanJia : MonoBehaviour
{
    public float speed = 1.0f;

    private Transform game;

    // Start is called before the first frame update
    void Start()
    {
        // 节点名称
        this.name = "DanJia";

        game = GameObject.Find("游戏主控").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dy = speed * Time.deltaTime;
        transform.Translate(0, -dy, 0);

        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.y < 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.name.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
