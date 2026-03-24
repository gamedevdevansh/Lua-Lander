////using System.Collections;
////using UnityEngine;
////using UnityEngine.SceneManagement;
////using TMPro;

////public class StartSceneUI : MonoBehaviour
////{
////    public TextMeshProUGUI textUI;  
////    public string fullText;

////    private bool isTyping = true;

////    public SceneFader fader;

////    public void StartGame()
////    {
////        if (isTyping)
////        {
////            StopAllCoroutines();
////            textUI.text = fullText;
////            isTyping = false;
////            return;
////        }

////        StartCoroutine(fader.FadeOut("LevelScene"));
////    }

////    //public void StartGame()
////    //{
////    //    if (isTyping)
////    //    {
////    //        StopAllCoroutines();
////    //        textUI.text = fullText;
////    //        isTyping = false;
////    //        return;
////    //    }

////    //    StartCoroutine(fader.FadeOut("LevelScene"));
////    //}

////}

//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;

//public class StartSceneUI : MonoBehaviour
//{
//    [Header("UI References")]
//    public TextMeshProUGUI textUI;
//    public SceneFader fader;

//    [Header("Text Settings")]
//    [TextArea]
//    public string fullText;
//    public float typingSpeed = 0.05f;

//    private bool isTyping = true;
//    private bool canClick = false;

//    void Start()
//    {
//        StartCoroutine(StartSequence());
//    }

//    IEnumerator StartSequence()
//    {
//        // Wait for fade-in to complete
//        yield return new WaitForSeconds(1f);

//        // Start typing text
//        yield return StartCoroutine(TypeText());

//        // Allow button click after typing finishes
//        canClick = true;
//    }

//    IEnumerator TypeText()
//    {
//        textUI.text = "";

//        foreach (char letter in fullText)
//        {
//            textUI.text += letter;
//            yield return new WaitForSeconds(typingSpeed);
//        }

//        isTyping = false;
//    }

//    // Button Function
//    public void StartGame()
//    {
//        // Prevent clicking too early
//        if (!canClick) return;

//        // If typing still going → skip instantly
//        if (isTyping)
//        {
//            StopAllCoroutines();
//            textUI.text = fullText;
//            isTyping = false;
//            return;
//        }

//        // Smooth transition to next scene
//        StartCoroutine(fader.FadeOut("LevelScene"));
//    }
//}

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public SceneFader fader;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
        //fader.FadeToScene("LevelScene");
        //"StartScene"
    }
}