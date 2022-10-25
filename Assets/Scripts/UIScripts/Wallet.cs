using System;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;

    [SerializeField] TextMeshProUGUI walletText;

    public int wallet;
    void Start()
    {
        Instance = this;
        WalletController();
    }

    void WalletController()
    {
        wallet = PlayerPrefs.GetInt("playerWallet");

        walletText.text = wallet.ToString();
    }
}
