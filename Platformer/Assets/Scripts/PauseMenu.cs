using UnityEngine;

public class PauseMenu : MonoBehaviour

{
    [SerializeField] private GameObject hero;

    private PauseController controller;
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("PauseController").GetComponent<PauseController>();
    }
    public void MainMenu()
    {
        controller.ToMenu();
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        controller.ResumeGame();
        hero.SetActive(true);
    }
    public void Restart()
    {
        ResetData();
        gameObject.SetActive(false);
        controller.Restart();
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
