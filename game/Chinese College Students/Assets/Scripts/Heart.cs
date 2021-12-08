using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{   

    private SpriteRenderer sr;
    public bool isEnemyHeart;
    public Sprite BrokenSprite; 
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Die()
    {

        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab,transform.position,transform.rotation);
        PlayerMananger.Instance.isDefeat = true;
        Invoke("ReturnToMenu",3);

    }
    private void ReturnToMenu() //返回主界面
    {
        SceneManager.LoadScene(0);
    }
}
