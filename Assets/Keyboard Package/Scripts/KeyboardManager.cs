using TMPro;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager Instance;
    [SerializeField] TMP_InputField tmpInputField;
    [SerializeField] GameObject keyboard;


    private void Start()
    {
        Instance = this;
        tmpInputField.text = PlayerPrefs.GetString("playerName");
    }

    public void DeleteLetter()
    {
        if(tmpInputField.text.Length != 0) {
            tmpInputField.text = tmpInputField.text.Remove(tmpInputField.text.Length - 1, 1);
        }
    }

    public void AddLetter(string letter)
    {
        tmpInputField.text = tmpInputField.text + letter;
    }

    public void SubmitWord()
    {
        keyboard.SetActive(false);
        //printBox.text = tmpInputField.text;
        //tmpInputField.text = "";
        // Debug.Log("Text submitted successfully!");
    }
}
