using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int level;
    public void OpenLevelsMenu()
    {
        LoadData();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        LoadData();
        SceneManager.LoadScene(level);
       
    }
    public void LoadData()
    {       
        if (PlayerPrefs.HasKey("LEVEL_KEY"))
            level = PlayerPrefs.GetInt("LEVEL_KEY");
        else level = 2;       
    }

}
