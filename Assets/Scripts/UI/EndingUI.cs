using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    [TextArea]
    public string fullText;

    private bool isTyping = true;

    public SceneFader fader;

    public void RestartGame()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            textUI.text = fullText;
            isTyping = false;
            return;
        }

        StartCoroutine(fader.FadeOut("StartScene"));
    }
}