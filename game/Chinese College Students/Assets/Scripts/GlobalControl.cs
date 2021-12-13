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
    public int[] Learnscore_perStage = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    // 不需要保存的数据
    public int IfNextStage = 0;
    private string[] startDate = new string[] { "2019/09/02", "2020/03/02", "2020/09/07", "2020/03/01", "2021/09/06", "2022/02/28", "2022/09/05", "2023/03/06" };
    private string[] endDate = new string[] { "2020/01/03", "2020/07/03", "2021/01/08", "2021/07/02", "2022/01/07", "2022/07/01", "2023/01/06", "2023/07/07" };
    private int learningDaySpan = 112;
    private int sportsDaySpan = 5;
    private int socialDaySpan = 5;
    private int clubDaySpan = 5;
    public int ExamScore = 0;
    public int DoingID = 0;
    public string[] GraduateTxt = new string[]
    {
        "你毕业了，拖着不大不小的行李箱，在四下喧闹时，无声的离开这所学校。大学这四年，很快，许多心事都在离开的一霎那烟消云散了。你不想哭，但还是流下了几滴泪水。",
        "他们说你是最成功的人。吃小马的时候，舍友笑着和你说，“苟富贵，不如相忘于江湖”。你笑了，清华的门再也拦不住你了，但你的青春被隔在门外，徘徊在回忆里。“不会忘的”，你违心的说。",
        "qs前十！offer下来的那一刻，你就已经离开了这所学校。回家过年的时候，爸妈难得语重心长，想让你留下来。“到了那边照顾好自己，别担心钱。”不解之后是支持，你呜咽了。",
        "你留在了学校，你憋红了脸，大声说着，“再给我一年！！”女朋友说：“我会在隔壁等你的”。梦醒了，你没有女朋友，她只是在你相册里深居的其中之一。失败者的梦永远香甜。"
    };
    public string[] EndingTxt = new string[]
    {
        "你进了大厂，你996，35岁，你被优化。葬礼那天，他们说good die young。你知道在老板眼里你不优秀，也不年轻。",
        "你在25岁那年发行了sufe币，五角场三校的学子为了你掏空了腰包。30岁那年，你镰刀一挥，卷款跑路。登上了spacex，坠毁在火星。",
        "“我爱你”，似乎世界毁灭也阻挡不了这三个字的脱口而出。“我也爱你，我们结婚吧。”几年后，你们在海岛边买了幢小别墅，幸福终老。",
        "“第九十九届提篮桥监狱篮球赛正式开幕”，掌声四起，你满不在乎的摇着头。你相信老板会来救你出去的。三年后，你出狱了。七十六岁的你已经不能理解世上发生的事情，你自然死去。",
        "你被称为“人民企业家”，你大手一挥，你给财大捐了两栋大楼，一栋以你的名字命名，另一栋，用她的。你的学弟学妹们会永远记住你，还有她。",
        "在地下室，你找到了大学桌子上那个狐狸布偶，它覆着灰，但它的眼睛还是闪着机灵的光。你把它仔细擦拭后放到了孙女的房间。她的机械狗冲着它轻轻的叫着，它们可能成为新朋友。"
    };

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
        endDate = new string[] {"2020/01/03", "2020/07/03", "2021/01/08", "2021/07/02", "2022/01/07", "2022/07/01", "2023/01/06", "2023/07/07"};
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
        Learnscore_perStage = new int[8];
        IfNextStage = 0;
        learningDaySpan = 7;
        sportsDaySpan = 7;
        socialDaySpan = 7;
        clubDaySpan = 7;
        ExamScore = 0;
        DoingID = 0;
        GraduateTxt = new string[]
    {
        "你毕业了，拖着不大不小的行李箱，在四下喧闹时，无声的离开这所学校。大学这四年，很快，许多心事都在离开的一霎那烟消云散了。你不想哭，但还是流下了几滴泪水。",
        "他们说你是最成功的人。吃小马的时候，舍友笑着和你说，“苟富贵，不如相忘于江湖”。你笑了，清华的门再也拦不住你了，但你的青春被隔在门外，徘徊在回忆里。“不会忘的”，你违心的说。",
        "qs前十！offer下来的那一刻，你就已经离开了这所学校。回家过年的时候，爸妈难得语重心长，想让你留下来。“到了那边照顾好自己，别担心钱。”不解之后是支持，你呜咽了。",
        "你留在了学校，你憋红了脸，大声说着，“再给我一年！！”女朋友说：“我会在隔壁等你的”。梦醒了，你没有女朋友，她只是在你相册里深居的其中之一。失败者的梦永远香甜。"
    };
        EndingTxt = new string[]
    {
        "你进了大厂，你996，35岁，你被优化。葬礼那天，他们说good die young。你知道在老板眼里你不优秀，也不年轻。",
        "你在25岁那年发行了sufe币，五角场三校的学子为了你掏空了腰包。30岁那年，你镰刀一挥，卷款跑路。登上了spacex，坠毁在火星。",
        "“我爱你”，似乎世界毁灭也阻挡不了这三个字的脱口而出。“我也爱你，我们结婚吧。”几年后，你们在海岛边买了幢小别墅，幸福终老。",
        "“第九十九届提篮桥监狱篮球赛正式开幕”，掌声四起，你满不在乎的摇着头。你相信老板会来救你出去的。三年后，你出狱了。七十六岁的你已经不能理解世上发生的事情，你自然死去。",
        "你被称为“人民企业家”，你大手一挥，你给财大捐了两栋大楼，一栋以你的名字命名，另一栋，用她的。你的学弟学妹们会永远记住你，还有她。",
        "在地下室，你找到了大学桌子上那个狐狸布偶，它覆着灰，但它的眼睛还是闪着机灵的光。你把它仔细擦拭后放到了孙女的房间。她的机械狗冲着它轻轻的叫着，它们可能成为新朋友。"
    };

}

    public void Reset()
    {
        Instance.stage = 1;
        Instance.date = Instance.startDate[stage - 1];
        Instance.ddl = Instance.endDate[stage - 1];
        Instance.FeijiClubScore = 0;
        Instance.JitaClubScore = 0;
        Instance.SocialScore = 0;
        Instance.LearningScore = 0;
        Instance.SportsScore = 0;
        Instance.SocialScore = 0;
        Instance.ClubTime = 0;
        Instance.LearnTime = 0;
        Instance.SocialTime = 0;
        Instance.SportsTime = 0;
        Instance.FinalScore = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    public int theDay2DDL()
    {
        DateTime ddl = Convert.ToDateTime(Instance.ddl);
        DateTime now = Convert.ToDateTime(Instance.date);
        TimeSpan span = ddl - now;
        int days = span.Days - 7;
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
        return GlobalControl.Instance.Learnscore_perStage[stage - 1]/20;
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