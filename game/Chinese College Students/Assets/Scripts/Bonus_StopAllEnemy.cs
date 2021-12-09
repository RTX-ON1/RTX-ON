using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_StopAllEnemy : MonoBehaviour
{   
    public float stopTimeVal = 0;
    // Start is called before the first frame update
    //public AudioSource stopAudio;
    public AudioClip BonusStopAudio;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StopAllEnemy()
    {
        Enemy.isStopEnemyBonusActive = true;
        
    }

    private void SetBonusFalse()
    {
        Enemy.isStopEnemyBonusActive = false;

    }
    public void PlayAudio()
    {   
        // stopAudio.clip = BonusStopAudio;
        // stopAudio.Play();
        AudioSource.PlayClipAtPoint(BonusStopAudio,transform.position);
    }
    
}
