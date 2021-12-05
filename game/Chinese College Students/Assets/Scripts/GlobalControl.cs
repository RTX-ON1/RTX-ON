using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    //Ҫ����ʹ�õ�����;
    public string date;
    public string ddl;
    public int FeijiClubScore;
    public int JitaClubScore;
    public int LHMScore;
    public int MathScore;
    public int ComputerScore;
    public int FinanceScore;

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
}