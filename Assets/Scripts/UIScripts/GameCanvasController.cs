using System;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;

    void Start()
    {
        
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
}
