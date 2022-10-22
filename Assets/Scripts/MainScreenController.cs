using TMPro;
using UnityEngine;

public class MainScreenController : MonoBehaviour
{
    public TMP_InputField textBox;

    void Start()
    {
        textBox.onValueChanged.AddListener(SaveName);
    }

    void SaveName(string arg0)
    {
        print(arg0);
        PlayerPrefs.SetString("playerName", arg0);
    }
}
