using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_AddLifeValue : MonoBehaviour
{   
    // public bool isAddLifeBonusActive;//判断是否激活增加生命的bonus
    // Start is called before the first frame update
    public AudioClip BonusAddLifeAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (isAddLifeBonusActive)
        // {
        //     PlayerMananger.Instance.lifeValue+=1;
        //     isAddLifeBonusActive = false;
        // }
    }

    private void addLife()
    {
        PlayerMananger.Instance.lifeValue+=1;

    }
    public void PlayAudio()
    {   
        // stopAudio.clip = BonusStopAudio;
        // stopAudio.Play();
        AudioSource.PlayClipAtPoint(BonusAddLifeAudio,transform.position);
    }
}
