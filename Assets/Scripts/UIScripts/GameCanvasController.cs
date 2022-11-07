using System;
using TMPro;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;

    public TextMeshProUGUI winLevelText;
    public TextMeshProUGUI loseLevelText;
    

    void Start()
    {
        PlayerControl.Instance.winGame += OpenWinUIAndWinGame;
        BotController.loseGame += OpenLoseUIAndLoseGame;
        LevelSetter();
    }

    void LevelSetter()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");

        if (currentLevel == 0)
            currentLevel = 1;

        winLevelText.text = "Episode " + currentLevel;
        loseLevelText.text = "Episode " + currentLevel;
    }

    void OpenWinUIAndWinGame()
    {
        winUI.SetActive(true);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);
    }
    
    void OpenLoseUIAndLoseGame()
    {
        loseUI.SetActive(true);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);
    }

    void OnDisable()
    {
        BotController.loseGame -= OpenLoseUIAndLoseGame;
        PlayerControl.Instance.winGame -= OpenWinUIAndWinGame;
    }
}
