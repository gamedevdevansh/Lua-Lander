using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneUI : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public float typingSpeed = 0.05f;

    [TextArea]
    public string fullText;

    private bool isTyping = true;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textUI.text = "";

        foreach (char letter in fullText)
        {
            textUI.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    // Button function
    public void StartGame()
    {
        // If typing is still going → skip animation first
        if (isTyping)
        {
            StopAllCoroutines();
            textUI.text = fullText;
            isTyping = false;
            return;
        }

        // If already finished → go to game
        SceneManager.LoadScene("LevelScene");
    }
}