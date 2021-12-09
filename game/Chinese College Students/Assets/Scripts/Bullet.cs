using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float moveSpeed = 15;
    public bool isPlayerBullet;//判断是否是玩家的子弹
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*moveSpeed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag) 
        {
            case"Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                    
                }
                break;
            case"Heart":
               
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                    break;
                    
            case"Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                                        
                }
                break;
                // else
                // {
                //     break;
                // }
            case"Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case"Barrier":
                if (isPlayerBullet)
                {
                    collision.SendMessage("PlayAudio");
                }                
                Destroy(gameObject);
                break;
            
            case"Bonus_AddLife":
                if (isPlayerBullet)
                {   
                    collision.SendMessage("PlayAudio");
                    collision.SendMessage("addLife");
                    Destroy(gameObject);
                    Destroy(collision.gameObject);             
                }
                break;

            case"Bonus_StopAllEnemy":
                if (isPlayerBullet)
                {   
                    collision.SendMessage("PlayAudio");
                    collision.SendMessage("StopAllEnemy");
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }
                break;
            
            case"Bonus_Bomb":
                if (isPlayerBullet)
                {   
                    collision.SendMessage("PlayAudio");
                    Bonus_Bomb.isBombActive = true;
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }
                break;
            
            case"SpecialAirBarriar":
                collision.SendMessage("changeVisible");
                Destroy(gameObject);
                break;
                
            default:
            break;
        }
    }
}
