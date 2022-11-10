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
    public TextMeshProUGUI winUIEarned;
    public TextMeshProUGUI winUIWallet;

    int earnedGold = 0;

    void Start()
    {
        PlayerControl.Instance.winGame += OpenWinUIAndWinGame;
        BotController.loseGame += OpenLoseUIAndLoseGame;
        PlayerControl.Instance.collectBricks += IncreaseEarnedGold;
        ButtonSessions.pushedNextLevelButton += SavePlayerMoney;
        LevelSetter();
    }

    void WinUITextSetter()
    {
        var currentMoney = PlayerPrefs.GetInt("playerMoney");
        winUIEarned.text = earnedGold + " $ KAZANDINIZ";
        winUIWallet.text = currentMoney.ToString();
    }

    void IncreaseEarnedGold()
    {
        earnedGold += 1;
    }

    void LevelSetter()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");

        if (currentLevel == 0)
            currentLevel = 1;

        winLevelText.text = "Bölüm " + currentLevel;
        loseLevelText.text = "Bölüm " + currentLevel;
    }

    void OpenWinUIAndWinGame()
    {
        winUI.SetActive(true);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);
        WinUITextSetter();
    }

    void SavePlayerMoney()
    {
        var currentMoney = PlayerPrefs.GetInt("playerMoney");

        var endMoney = currentMoney + earnedGold;
        
        PlayerPrefs.SetInt("playerMoney", endMoney);
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
        PlayerControl.Instance.collectBricks -= IncreaseEarnedGold;
        BotController.loseGame -= OpenLoseUIAndLoseGame;
        PlayerControl.Instance.winGame -= OpenWinUIAndWinGame;
        ButtonSessions.pushedNextLevelButton -= SavePlayerMoney;
    }
}
