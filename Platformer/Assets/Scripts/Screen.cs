using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour
{
    public AudioSource Sound;
    private void Start()
    {
        Sound.Play();
    }
    public void MainMenu()
    {
        ResetData();
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        ResetData();
        SceneManager.LoadScene(2);

    }
    private void ResetData()
    {
        PlayerPrefs.DeleteKey("COIN_KEY");
        PlayerPrefs.DeleteKey("LEVEL_KEY");
        PlayerPrefs.DeleteKey("HEALTH_KEY");
        PlayerPrefs.DeleteKey("X_KEY");
        PlayerPrefs.DeleteKey("Y_KEY");
    }
}
