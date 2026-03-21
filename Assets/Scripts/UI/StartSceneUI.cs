using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
