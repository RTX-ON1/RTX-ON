using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject LoadGamePanel;
    public GameObject SettingsPanel;

    // Start is called before the first frame update

    public void Play()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
            LoadGamePanel.SetActive(true);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        GameObject.Find("Canvas").GetComponent<SaveGame>().LoadGameFunc();
        SceneManager.LoadScene("Main Stage");
    }

    public void onclickSettings()
    {
        SettingsPanel.SetActive(true);
    }
    
    public void GoToMainMenu()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void onclickReturn1()
    {
        LoadGamePanel.SetActive(false);
    }

    public void onclickReturn2()
    {
        SettingsPanel.SetActive(false);
    }

}
