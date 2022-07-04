using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    public void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        ResumeGame();
        SceneManager.LoadScene(2);
    }
    public void ToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}
