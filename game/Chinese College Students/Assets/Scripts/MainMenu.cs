using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public GameObject LoadGamePanel;
    public GameObject SettingsPanel;
    public GameObject AudioSettingsPanel;
    public Slider AudioControlSlider;

    // Start is called before the first frame update
    public void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
            AudioControlSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        else AudioControlSlider.value = 1;
    }

    public void Play()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
            LoadGamePanel.SetActive(true);
        else SceneManager.LoadScene("Main Stage");
    }

    public void PlayGame(int num)
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

    public void onclickAudioSettings()
    {
        AudioSettingsPanel.SetActive(true);
    }

    public void onclickReturn1()
    {
        LoadGamePanel.SetActive(false);
    }

    public void onclickReturn2()
    {
        SettingsPanel.SetActive(false);
    }

    public void onclickReturn3()
    {
        AudioSettingsPanel.SetActive(false);
    }

    public void AudioControl()
    {
        PlayerPrefs.SetFloat("BGMVolume", AudioControlSlider.value);
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");

    }

    public void deleteSave(int num)
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            File.Delete(Application.persistentDataPath + "/gamesave.save");
            Debug.Log("删除成功");
            GlobalControl.Instance.Reset();
            LoadGamePanel.SetActive(false);

        }
        else
        {
            Debug.Log("没有找到存档");
        }
    }

}
