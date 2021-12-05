using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStage : MonoBehaviour
{

    public GameObject DateText;
    public GameObject ActText;
    public GameObject StudyText;

    // Start is called before the first frame update
    void Start()
    {
        setDateText();
        setActText();
        setStudyText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDateText()
    {

        Text txt = DateText.GetComponent<Text>();
        txt.text = GlobalControl.Instance.date + "\n距离ddl还有\n" + theDay2DDL();

    }

    public string theDay2DDL()
    {
        string day = "0天";
        return day;
    }

    public void setActText()
    {

        Text txt = ActText.GetComponent<Text>();
        txt.text = "社团：\n\t飞机社：" + GlobalControl.Instance.FeijiClubScore.ToString() + "\n\t吉他社：" + GlobalControl.Instance.JitaClubScore.ToString() + "\n社交：\n\t李浩民：" + GlobalControl.Instance.LHMScore.ToString();
        
    }

    public void setStudyText()
    {

        Text txt = StudyText.GetComponent<Text>();
        txt.text = "学习：\n\t数学：" + GlobalControl.Instance.MathScore.ToString() + "\n\t编程：" + GlobalControl.Instance.ComputerScore.ToString() + "\n\t会计：" + GlobalControl.Instance.FinanceScore.ToString();

    }

    public void onclickMap()
    {

    }

}
