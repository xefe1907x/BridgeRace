using TMPro;
using UnityEngine;

public class MainScreenController : MonoBehaviour
{
    public TMP_InputField textBox;
    public TextMeshProUGUI episodeText;

    int episode;
    void Start()
    {
        textBox.onValueChanged.AddListener(SaveName);
        EpisodeController();
    }

    void EpisodeController()
    {
        if (PlayerPrefs.GetInt("playerEpisode") == 0)
        {
            episode = 1;
        }
        else
        {
            episode = PlayerPrefs.GetInt("playerEpisode");
        }

        episodeText.text = "Bölüm " + episode;
    }

    void SaveName(string arg0)
    {
        PlayerPrefs.SetString("playerName", arg0);
    }
}
