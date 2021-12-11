using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance = new GlobalControl();

    //要保存的数据;

    // 当前游戏为第几代第几个阶段
    public int generation = 1;
    public int stage = 1;

    // 当前游戏人物的天赋


    // 当前玩家的得分
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

    // 不需要保存的数据
    public int IfNextStage = 0;
    private string[] startDate = new string[] { "2019/09/02", "2020/03/02", "2020/09/07", "2020/03/01", "2021/09/06", "2022/02/28", "2022/09/05", "2023/03/06" };
    private string[] endDate = new string[] { "2020/01/03", "2020/07/03", "2021/01/08", "2020/07/02", "2022/01/07", "2022/07/01", "2023/01/06", "2023/07/07" };
    private int learningDaySpan = 5;
    private int sportsDaySpan = 5;
    private int socialDaySpan = 5;
    private int clubDaySpan = 5;
    public int ExamScore = 0;

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

        startDate = new string[] { "2019/09/02", "2020/03/02", "2020/09/07", "2021/03/01", "2021/09/06", "2022/02/28", "2022/09/05", "2023/03/06" };
        endDate = new string[] {"2020/01/03", "2020/07/03", "2021/01/08", "2020/07/02", "2022/01/07", "2022/07/01", "2023/01/06", "2023/07/07"};
        stage = 1;
        date = startDate[stage - 1];
        ddl = endDate[stage - 1];
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
        IfNextStage = 0;
        learningDaySpan = 5;
        sportsDaySpan = 5;
        socialDaySpan = 5;
        clubDaySpan = 5;
        ExamScore = 0;

    }

    public void Reset()
    {
        Instance = new GlobalControl();
    }

    public int theDay2DDL()
    {
        DateTime ddl = Convert.ToDateTime(Instance.ddl);
        DateTime now = Convert.ToDateTime(Instance.date);
        TimeSpan span = ddl - now;
        int days = span.Days;
        return days;
    }

    public void DayPassLearn()
    {
        DateTime now = Convert.ToDateTime(Instance.date);
        now = now.AddDays(Instance.learningDaySpan);
        Instance.date = now.ToShortDateString();
    }

    public void DayPassSports()
    {
        DateTime now = Convert.ToDateTime(Instance.date);
        now = now.AddDays(Instance.sportsDaySpan);
        Instance.date = now.ToShortDateString();
    }

    public void DayPassClub()
    {
        DateTime now = Convert.ToDateTime(Instance.date);
        now = now.AddDays(Instance.clubDaySpan);
        Instance.date = now.ToShortDateString();
    }

    public void DayPassSocial()
    {
        DateTime now = Convert.ToDateTime(Instance.date);
        now = now.AddDays(Instance.socialDaySpan);
        Instance.date = now.ToShortDateString();
    }

    public void toNextStage()
    {
        Instance.stage += 1;
        Instance.date = Instance.startDate[Instance.stage - 1];
        Instance.ddl = Instance.endDate[Instance.stage - 1];
    }

    public int ToLearningScore(int score)
    {
        return score;
    }

    public int ToSportsScore(int score)
    {
        return score;
    }

    public int ToClubScore(int score)
    {
        return score;
    }

    public int ToSocialScore(int score)
    {
        return score;
    }

    public int ToExamScore(int score)
    {
        return score;
    }

    public int SecondsForExam()
    {
        return 10;
    }
    public int Cal_score(int rank )
    {
        int score = 0;
        if (rank == 1)
        {
            score = 100;
        }
        else if (rank == 2)
        {
            score = 80;
        }
        else if (rank == 3)
        {
            score = 60;
        }
        else score = 50;

        return score;
    }
}