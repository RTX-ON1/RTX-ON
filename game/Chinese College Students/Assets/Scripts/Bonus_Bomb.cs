using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Bomb : MonoBehaviour
{   
    //bomb的具体实现算法在MapCreation脚本中。
    public static bool isBombActive;
    private int enemyListLength;
    public AudioClip BonusBombAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio()
    {   
        // stopAudio.clip = BonusStopAudio;
        // stopAudio.Play();
        AudioSource.PlayClipAtPoint(BonusBombAudio,transform.position);
    }

    
}
