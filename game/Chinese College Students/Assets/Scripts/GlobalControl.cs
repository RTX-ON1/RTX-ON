using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    //Ҫ���������;

    // ��ǰ��ϷΪ�ڼ����ڼ����׶�
    public int generation;
    public int stage;

    // ��ǰ��Ϸ������츳


    // ��ǰ��ҵĵ÷�
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

    // ����Ҫ���������
    public int IfNextStage;

    //��ʼ��
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
        date = "2019/09/01";
        ddl = "2019/12/31";
        FeijiClubScore = 0;
        JitaClubScore = 0;
        SocialScore = 0;
        LearningScore = 0;
        SportsScore = 0;
        ClubTime = 0;
        LearnTime = 0;
        SocialTime = 0;
        SportsTime = 0;
        FinalScore = new int[8];
    }

    public void Reset()
    {
        Instance = new GlobalControl();
    }

}