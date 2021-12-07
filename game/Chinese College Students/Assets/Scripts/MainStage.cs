
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainStage : MonoBehaviour
{

    public GameObject DateText;
    public GameObject ActText;
    public GameObject StudyText;
    public GameObject MapPanel;
    public GameObject EventPanel;
    public TextAsset EventsData;
    public string[] Events;
    public int EventNum;

    // Start is called before the first frame update
    void Start()
    {
        setDateText();
        setActText();
        setStudyText();
        LoadEvents();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt = Convert.ToDateTime(GlobalControl.Instance.date);
        int year = dt.Year;
        int month = dt.Month;
        int day = dt.Day;
        if (month == 6 && day == 30)
        {
            month = 9; day = 1;
        }
        else
        {
            if (month == 12 && day == 30)
            {
                year += 1; month = 3; day = 1;
            }
            else
            {
                dt = dt.AddDays(15);
                month = dt.Month;
                day = dt.Day;
            }
        }
        GlobalControl.Instance.date = year + "��" + month + "��" + day + "��";
        Text txt = DateText.GetComponent<Text>();
        txt.text = GlobalControl.Instance.date + "\n����ddl����\n" + theDay2DDL();




    }

    public void setDateText()
    {

        GlobalControl.Instance.date = "2019��9��1��";
        Text txt = DateText.GetComponent<Text>();
        txt.text = GlobalControl.Instance.date + "\n����ddl����\n" + theDay2DDL();

    }

    public string theDay2DDL()
    {
        DateTime dt = Convert.ToDateTime(GlobalControl.Instance.date);
        if (dt.DayOfYear < 181)
        {
            int day_span = 180 - dt.DayOfYear;
        }
        else
        {
            day_span = 365 - dt.DayOfYear;
        }

        string day = day_span.ToString() + "��" ;

        return day;
    }

    public void setActText()
    {

        Text txt = ActText.GetComponent<Text>();
        txt.text = "���ţ�\n\t�ɻ��磺" + GlobalControl.Instance.FeijiClubScore.ToString() + "\n\t�����磺" + GlobalControl.Instance.JitaClubScore.ToString() + "\n�罻��\n\t�����" + GlobalControl.Instance.SocialScore.ToString();
        
    }

    public void setStudyText()
    {

        Text txt = StudyText.GetComponent<Text>();
        txt.text = "ѧϰ��\n\t������" + GlobalControl.Instance.LearningScore.ToString() + "\n\t������" + GlobalControl.Instance.LearnTime.ToString() + "\n������\n\t���ʣ�" + GlobalControl.Instance.SportsScore.ToString();

    }

    public void onclickMap()
    {
        MapPanel.SetActive(true);
    }

    public void onclickSprots()
    {

    }

    public void onclickLearn()
    {

    }

    public void onclickClub()
    {

    }

    public void onclickSocial()
    {

    }

    public void onclickCloseMap()
    {
        MapPanel.SetActive(false);
    }

    public void randomEvent(int ToDo, int Done)
    {
        int i = EventNum/2;
        while (i > 0)
        {
            int E = Random.Range(0, EventNum - 1);
            string[] EventItem = Events[E].Split(',');
            if(GlobalControl.Instance.LearningScore > double.Parse(EventItem[1]) && GlobalControl.Instance.LearningScore < double.Parse(EventItem[2])
                && GlobalControl.Instance.LearnTime > double.Parse(EventItem[3]) && GlobalControl.Instance.LearnTime < double.Parse(EventItem[4])
                && GlobalControl.Instance.SportsScore > double.Parse(EventItem[5]) && GlobalControl.Instance.SportsScore < double.Parse(EventItem[6])
                && GlobalControl.Instance.SportsTime > double.Parse(EventItem[7]) && GlobalControl.Instance.SportsTime < double.Parse(EventItem[8])
                && GlobalControl.Instance.FeijiClubScore > double.Parse(EventItem[9]) && GlobalControl.Instance.FeijiClubScore < double.Parse(EventItem[10])
                && GlobalControl.Instance.ClubTime > double.Parse(EventItem[11]) && GlobalControl.Instance.ClubTime < double.Parse(EventItem[12])
                && GlobalControl.Instance.SocialScore > double.Parse(EventItem[13]) && GlobalControl.Instance.SocialScore < double.Parse(EventItem[14])
                && GlobalControl.Instance.SocialTime > double.Parse(EventItem[15]) && GlobalControl.Instance.SocialTime < double.Parse(EventItem[16])
                && !(isBeginningOfTerm() == 0 && double.Parse(EventItem[17]) == 1) && !(isEndOfTerm() == 0 && double.Parse(EventItem[18]) == 1)
                && (double.Parse(EventItem[19]) == 0 || ToDo == double.Parse(EventItem[19])) && (double.Parse(EventItem[20]) == 0 || Done == double.Parse(EventItem[20])))
            {
                EventHappen(int.Parse(EventItem[0]));
            }
        }

    }

    public void LoadEvents()
    {
        Events = EventsData.text.Split('\n');
        EventNum = Events.Length;
    }

    public int isBeginningOfTerm()
    {
        return 1;
    }

    public int isEndOfTerm()
    {
        return 1;
    }

    public void EventHappen(int ID)
    {
        EventPanel.SetActive(true);
    }

}
