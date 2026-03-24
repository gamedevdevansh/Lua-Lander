//using UnityEngine;
//using UnityEngine.SceneManagement;

//public static class SceneLoader {

//    public enum Scene
//    {
//        MainMenuScene,
//        StartScene,
//        LevelScene,
//        GameScene,
//        GameOverScene, 
//        EndScene
//    }

//    public static void LoadScene(Scene scene)
//    {
//        SceneManager.LoadScene(scene.ToString());
//    }

//}
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public enum Scene
    {
        MainMenuScene,
        StartScene,
        LevelScene,
        GameScene,
        GameOverScene,
        EndScene
    }

    public Image fadeImage;
    public float duration = 1f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void Load(Scene scene)
    {
        StartCoroutine(FadeOut(scene.ToString()));
    }

    IEnumerator FadeIn()
    {
        float t = duration;

        while (t > 0)
        {
            t -= Time.deltaTime;
            SetAlpha(t / duration);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            SetAlpha(t / duration);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    void SetAlpha(float a)
    {
        Color c = fadeImage.color;
        c.a = a;
        fadeImage.color = c;
    }
}