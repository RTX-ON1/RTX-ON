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
    public AudioClip dieAudio;
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
        AudioSource.PlayClipAtPoint(dieAudio,transform.position);

    }
    private void ReturnToMenu() //返回主界面
    {
        SceneManager.LoadScene("Main Stage");
    }
}
