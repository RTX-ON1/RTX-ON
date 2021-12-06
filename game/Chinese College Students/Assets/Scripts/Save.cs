using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    //要保存的数据;

    // 当前游戏为第几代第几个阶段
    public int generation;
    public int stage;

    // 当前游戏人物的天赋


    // 当前玩家的得分
    public string date;
    public string ddl;
    public int FeijiClubScore;
    public int JitaClubScore;
    public int SocialScore;
    public int LearningScore;
    public int SportsScore;
    public int ClubTime;
    public int LearnTime;
    public int SocialTime;
    public int SportsTime;
}
