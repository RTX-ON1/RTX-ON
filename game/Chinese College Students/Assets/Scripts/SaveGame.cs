using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.generation = GlobalControl.Instance.generation;
        save.stage = GlobalControl.Instance.stage;
        save.date = GlobalControl.Instance.date;
        save.ddl = GlobalControl.Instance.ddl;
        save.FeijiClubScore = GlobalControl.Instance.FeijiClubScore;
        save.JitaClubScore = GlobalControl.Instance.JitaClubScore;
        save.SocialScore = GlobalControl.Instance.SocialScore;
        save.LearningScore = GlobalControl.Instance.LearningScore;
        save.SportsScore = GlobalControl.Instance.SportsScore;
        save.ClubTime = GlobalControl.Instance.ClubTime;
        save.LearnTime = GlobalControl.Instance.LearnTime;
        save.SocialTime = GlobalControl.Instance.SocialTime;
        save.SportsTime = GlobalControl.Instance.SportsTime;
        for(int i = 0; i < 8; i++)
        {
            save.FinalScore[i] = GlobalControl.Instance.FinalScore[i];
        }
        return save;
    }

    public void SaveGameFunc()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("存档完成");
    }

    public void LoadGameFunc()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            GlobalControl.Instance.generation = save.generation;
            GlobalControl.Instance.stage = save.stage;
            GlobalControl.Instance.date = save.date;
            GlobalControl.Instance.ddl = save.ddl;
            GlobalControl.Instance.FeijiClubScore = save.FeijiClubScore;
            GlobalControl.Instance.JitaClubScore = save.JitaClubScore;
            GlobalControl.Instance.SocialScore = save.SocialScore;
            GlobalControl.Instance.LearningScore = save.LearningScore;
            GlobalControl.Instance.SportsScore = save.SportsScore;
            GlobalControl.Instance.ClubTime = save.ClubTime;
            GlobalControl.Instance.LearnTime = save.LearnTime;
            GlobalControl.Instance.SocialTime = save.SocialTime;
            GlobalControl.Instance.SportsTime = save.SportsTime;
            for(int i = 0; i < 8; i++)
            {
                GlobalControl.Instance.FinalScore[i] = save.FinalScore[i];
            }

            Debug.Log("读档完成");
        }
        else Debug.Log("未找到此存档");
    }

}
