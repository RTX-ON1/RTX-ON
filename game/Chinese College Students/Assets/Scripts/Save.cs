using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    //Ҫ���������;

    // ��ǰ��ϷΪ�ڼ����ڼ����׶�
    public int generation = 1;
    public int stage = 1;

    // ��ǰ��Ϸ������츳


    // ��ǰ��ҵĵ÷�
    public string date = "2019/09/01";
    public string ddl = "2019/12/31";
    public int FeijiClubScore = 0;
    public int JitaClubScore = 0;
    public int SocialScore = 0;
    public int LearningScore = 0;
    public int SportsScore = 0;
    public int ClubTime = 0;
    public int LearnTime = 0;
    public int SocialTime = 0;
    public int SportsTime = 0;
    public int[] FinalScore = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
}
