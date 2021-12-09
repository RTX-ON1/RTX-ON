using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    //要保存的数据;

    // 当前游戏为第几代第几个阶段
    public int generation;
    public int stage;

    // 当前游戏人物的天赋


    // 当前玩家的得分
    public string date = "2019/09/01";
    public string ddl = "2019/12/31";
    public int FeijiClubScore;
    public int JitaClubScore;
    public int SocialScore;
    public int LearningScore;
    public int SportsScore;
    public int ClubTime;
    public int LearnTime;
    public int SocialTime;
    public int SportsTime;
    public int[] FinalScore;

    // 不需要保存的数据
    public int IfNextStage;

    //初始化
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public GlobalControl()
    {
        FinalScore = new int[8];
    }

}