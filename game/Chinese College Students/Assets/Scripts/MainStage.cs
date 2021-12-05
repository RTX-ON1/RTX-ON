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
        txt.text = GlobalControl.Instance.date + "\n����ddl����\n" + theDay2DDL();

    }

    public string theDay2DDL()
    {
        string day = "0��";
        return day;
    }

    public void setActText()
    {

        Text txt = ActText.GetComponent<Text>();
        txt.text = "���ţ�\n\t�ɻ��磺" + GlobalControl.Instance.FeijiClubScore.ToString() + "\n\t�����磺" + GlobalControl.Instance.JitaClubScore.ToString() + "\n�罻��\n\t�����" + GlobalControl.Instance.LHMScore.ToString();
        
    }

    public void setStudyText()
    {

        Text txt = StudyText.GetComponent<Text>();
        txt.text = "ѧϰ��\n\t��ѧ��" + GlobalControl.Instance.MathScore.ToString() + "\n\t��̣�" + GlobalControl.Instance.ComputerScore.ToString() + "\n\t��ƣ�" + GlobalControl.Instance.FinanceScore.ToString();

    }

    public void onclickMap()
    {

    }

}
