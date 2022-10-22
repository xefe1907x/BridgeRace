using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSessions : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentLevel;
        int nextLevel;
        
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        nextLevel = currentLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }
}
