using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {

    public enum Scene
    {
        MainMenuScene,
        StartScene,
        LevelScene,
        GameScene,
        GameOverScene, 
        EndScene
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

}

