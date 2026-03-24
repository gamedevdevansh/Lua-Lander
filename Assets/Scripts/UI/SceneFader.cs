////using System.Collections;
////using UnityEngine;
////using UnityEngine.UI;
////using UnityEngine.SceneManagement;

////public class SceneFader : MonoBehaviour
////{
////    public Image fadeImage;
////    public float fadeDuration = 1f;

////    void Start()
////    {
////        StartCoroutine(FadeIn());
////    }

////    public IEnumerator FadeIn()
////    {
////        float t = fadeDuration;
////        while (t > 0)
////        {
////            t -= Time.deltaTime;
////            SetAlpha(t / fadeDuration);
////            yield return null;
////        }
////    }

////    public IEnumerator FadeOut(string sceneName)
////    {
////        float t = 0;
////        while (t < fadeDuration)
////        {
////            t += Time.deltaTime;
////            SetAlpha(t / fadeDuration);
////            yield return null;
////        }

////        SceneManager.LoadScene(sceneName);
////    }

////    void SetAlpha(float alpha)
////    {
////        Color c = fadeImage.color;
////        c.a = alpha;
////        fadeImage.color = c;
////    }
////}


//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class SceneFader : MonoBehaviour
//{
//    public Image fadeImage;
//    public float fadeDuration = 1f;

//    void Start()
//    {
//        StartCoroutine(FadeIn());
//    }

//    public IEnumerator FadeIn()
//    {
//        fadeImage.raycastTarget = true;

//        float t = fadeDuration;
//        while (t > 0)
//        {
//            t -= Time.deltaTime;
//            SetAlpha(t / fadeDuration);
//            yield return null;
//        }

//        fadeImage.raycastTarget = false;
//    }

//    public IEnumerator FadeOut(string sceneName)
//    {
//        fadeImage.raycastTarget = true;

//        float t = 0;
//        while (t < fadeDuration)
//        {
//            t += Time.deltaTime;
//            SetAlpha(t / fadeDuration);
//            yield return null;
//        }

//        SceneManager.LoadScene(sceneName);
//    }

//    void SetAlpha(float alpha)
//    {
//        Color c = fadeImage.color;
//        c.a = alpha;
//        fadeImage.color = c;
//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float duration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
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