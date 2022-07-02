using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button[] level;

    private void Start()
    {
        int levelReach = PlayerPrefs.GetInt("levelReach", 1);
        for (int i = 0; i < level.Length; i++)
            if (i + 1 > levelReach)
                level[i].interactable = false;
    }
    public void Select(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }
}
