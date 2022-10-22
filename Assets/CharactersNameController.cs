using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharactersNameController : MonoBehaviour
{
    public TextMeshProUGUI characterName1; // Player name
    public TextMeshProUGUI characterName2; // Red bot name
    public TextMeshProUGUI characterName3; // Green bot name
    public TextMeshProUGUI characterName4; // Yellow bot name

    List<string> botNames = new List<string>
    {
        "kamil", "abuzer", "bmwci", "trolman", "zaaXD", "MAAE", "flyer12", "stella", "TheFlower", "Dracula", "Hanrick", "F1_mertcan", "spaydirmen",
        "nameyok", "aslan1234", "JimCarrey", "Thor", "OdinSon", "Guzzerman", "Stark", "Lee Sins", "Rohirrim", "Balrog", "Suuuu", "CR7", "GeymDeveloper", "Sezercik",
        "Hasansio", "Pepsi", "cancancan", "Sodexo", "Nixe", "MIA", "FBI", "SOSOSOS", "SERGIO", "Hens", "Soundyya", "Hahaha", "malrog", "Satat", "Nusret", "Caparen", "SOE"
    };
    
    void Start()
    {
        botNames.Shuffle();
        BotNameSelector();
        NameController();
    }



    void BotNameSelector()
    {
        
    }

    void NameController()
    {
        
    }
}

public static class ListShuffler
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
