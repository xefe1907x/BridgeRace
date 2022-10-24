using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSessions : MonoBehaviour
{
    int currentLevel;
    void Start()
    {
        CurrentLevelController();
    }

    void CurrentLevelController()
    {
        if (PlayerPrefs.GetInt("currentLevel") == 0)
        {
            currentLevel = 1;
        }

        else
        {
            currentLevel = PlayerPrefs.GetInt("currentLevel");
        }
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void LoadNextLevel()
    {
        int nextLevel;
        
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel = currentLevel + 1;
        PlayerPrefs.SetInt("currentLevel", nextLevel);
        SceneManager.LoadScene(nextLevel);
    }
}
