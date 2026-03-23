using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public string fullText;

    private bool isTyping = true;

    public SceneFader fader;

    public void StartGame()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            textUI.text = fullText;
            isTyping = false;
            return;
        }

        StartCoroutine(fader.FadeOut("LevelScene"));
    }
}