
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
    public GameObject FinalExamPanel;
    public TextAsset EventsData;
    public string[] Events;
    public int EventNum;
    public AudioSource BGM;
    public Slider BGMSlider;
    public GameObject TutorialPanel;
    public GameObject NextStagePanel;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start called");
        LoadEvents();
        if (!PlayerPrefs.HasKey("MainStageTutorial"))
        {
            PlayerPrefs.SetInt("MainStageTutorial", 1);
            TutorialPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            TutorialPanel.SetActive(false);
        }
    }

    void OnEnable()
    {
        RefreshText();
        setBGM();
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(GlobalControl.Instance.theDay2DDL() < 5)
        {
            FinalExamPanel.SetActive(true);
        }
        if(GlobalControl.Instance.IfNextStage == 1)
        {
            GlobalControl.Instance.IfNextStage = 0;
            NextStagePanel.SetActive(true);
            GameObject.Find("FinalExamScoreText").GetComponent<Text>().text = "这次期末考了" + GlobalControl.Instance.FinalScore[GlobalControl.Instance.stage].ToString() + "分";
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log(mode);
    }

    public void setDateText()
    {
        
        Text txt = DateText.GetComponent<Text>();
        txt.text = GlobalControl.Instance.date + "\n距离期末考试还有\n" + GlobalControl.Instance.theDay2DDL().ToString() + "天";
        //Debug.Log("date text set");

    }

    public void setActText()
    {

        Text txt = ActText.GetComponent<Text>();
        txt.text = "社团：\n\t飞机社：" + GlobalControl.Instance.FeijiClubScore.ToString()  + "\n\t次数: " + GlobalControl.Instance.ClubTime.ToString() + "\n社交：\n\t李浩民：" + GlobalControl.Instance.SocialScore.ToString() + "\n\t次数：" + GlobalControl.Instance.SocialTime.ToString();
        //Debug.Log("act text set");

    }

    public void setStudyText()
    {
        Text txt = StudyText.GetComponent<Text>();
        txt.text = "\t学习：" + GlobalControl.Instance.LearningScore.ToString() + "\n\t次数：" + GlobalControl.Instance.LearnTime.ToString() + "\n\n\t体育：" + GlobalControl.Instance.SportsScore.ToString() + "\n\t次数：" + GlobalControl.Instance.SportsTime.ToString();
        //Debug.Log("study text set");

    }

    public void onclickMap()
    {
        if(GlobalControl.Instance.theDay2DDL() >= 5)
            MapPanel.SetActive(true);
    }

    public void onclickMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void onclickSprots()
    {
        GlobalControl.Instance.DayPassSports();
        int num = Random.Range(0,4);

        switch (num)
        {
            case 0 : SceneManager.LoadScene("LongRun"); break;
            case 1 : SceneManager.LoadScene("ShortRun"); break;
            case 2 : SceneManager.LoadScene("Pullup_Situp"); break;
            case 3 : SceneManager.LoadScene("VitalCapacity"); break;
        }
    }

    public void onclickLearn()
    {
        randomEvent(1, 0);
        GlobalControl.Instance.DayPassLearn();
        SceneManager.LoadScene("Learning Game");
    }

    public void onclickClub()
    {
        GlobalControl.Instance.DayPassClub();
        SceneManager.LoadScene("Plane Fight");
    }

    public void onclickSocial()
    {
        GlobalControl.Instance.DayPassSocial();
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

    public void onclickNextStage()
    {
        NextStagePanel.SetActive(false);
        toNextStage();
    }

    public void toNextStage()
    {
        GlobalControl.Instance.toNextStage();
        RefreshText();
    }

    public void randomEvent(int ToDo, int Done) //1学习2运动3社团4社交
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
                EventHappen(EventItem[21], EventItem[22]);
                break;
            }
            i--;
        }
    }

    public void LoadEvents()
    {
        Events = EventsData.text.Split('\n');
        EventNum = Events.Length;
        //Debug.Log(Events[0]);
    }

    public int isBeginningOfTerm()
    {
        return 1;
    }

    public int isEndOfTerm()
    {
        return 1;
    }

    public void EventHappen(string Title, string Contents)
    {
        EventPanel.SetActive(true);
        GameObject.Find("EventName").GetComponent<Text>().text = Title;
        GameObject.Find("Event").GetComponent<Text>().text = Contents;
        Debug.Log("Event Happen");
    }

    public void BGMControl()
    {
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
    }

    public void RefreshText()
    {
        setDateText();
        setActText();
        setStudyText();
    }

    public void FinalExam()
    {
        GlobalControl.Instance.IfNextStage = 1;
        GlobalControl.Instance.ExamScore = 0;
        Debug.Log(GlobalControl.Instance.IfNextStage);
        SceneManager.LoadScene("Examination");
    }

    public void setBGM()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
            BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        else BGMSlider.value = 1;
    }

}
