using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {

    public enum Scene
    {
        MainMenuScene,
        LevelScene,
        GameScene,
        GameOverScene,
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

}

