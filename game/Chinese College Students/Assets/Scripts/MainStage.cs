
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class MainStage : MonoBehaviour
{

    public GameObject DateText;
    public GameObject ActText;
    public GameObject StudyText;
    public GameObject MapPanel;
    public GameObject EventPanel;
    public GameObject MenuPanel;
    public TextAsset EventsData;
    public string[] Events;
    public int EventNum;
    public AudioSource BGM;
    public Slider BGMSlider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start called");
        LoadEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        RefreshText();
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    public void setDateText()
    {

        GlobalControl.Instance.date = "2019/09/01";
        Text txt = DateText.GetComponent<Text>();
        txt.text = GlobalControl.Instance.date + "\n距离ddl还有\n" + theDay2DDL();
        Debug.Log("date text set");

    }

    public string theDay2DDL()
    {
        DateTime dt = Convert.ToDateTime(GlobalControl.Instance.date);
        int day_span;
        if (dt.DayOfYear < 181)
        {
            day_span = 180 - dt.DayOfYear;
        }
        else
        {
            day_span = 365 - dt.DayOfYear;
        }

        string day = day_span.ToString() + "天" ;

        return day;
    }

    public void setActText()
    {

        Text txt = ActText.GetComponent<Text>();
        txt.text = "社团：\n\t动漫社：" + GlobalControl.Instance.FeijiClubScore.ToString() + "\n\t吉他社：" + GlobalControl.Instance.JitaClubScore.ToString() + "\n社交：\n\t李浩民：" + GlobalControl.Instance.SocialScore.ToString();
        Debug.Log("act text set");

    }

    public void setStudyText()
    {

        Text txt = StudyText.GetComponent<Text>();
        txt.text = "学习：\n\t分数：" + GlobalControl.Instance.LearningScore.ToString() + "\n\t时间：" + GlobalControl.Instance.LearnTime.ToString() + "\n体育：\n\t分数：" + GlobalControl.Instance.SportsScore.ToString();
        Debug.Log("study text set");

    }

    public void onclickMap()
    {
        MapPanel.SetActive(true);
    }

    public void onclickMenu()
    {
        if(MenuPanel.activeSelf == true)
            MenuPanel.SetActive(false);
        else MenuPanel.SetActive(true);
    }

    public void onclickSprots()
    {

    }

    public void onclickLearn()
    {

    }

    public void onclickClub()
    {
        SceneManager.LoadScene("Learning Game");
    }

    public void onclickSocial()
    {
        SceneManager.LoadScene("tankwar");
    }

    public void onclickCloseMap()
    {
        MapPanel.SetActive(false);
    }

    public void onclickCloseMenu()
    {
        MenuPanel.SetActive(false);
    }

    public void onclickExit()
    {
        GameObject.Find("Canvas").GetComponent<SaveGame>().SaveGameFunc();
        SceneManager.LoadScene("Main Menu");
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
        Debug.Log("events loaded");
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

    public void BGMControl()
    {
        BGM.volume = BGMSlider.value;
    }

    public void RefreshText()
    {
        setDateText();
        setActText();
        setStudyText();
    }

    public void FinalExam()
    {
        SceneManager.LoadScene("Examination");
    }

}
