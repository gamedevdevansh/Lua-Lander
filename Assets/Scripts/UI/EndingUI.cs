using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
}