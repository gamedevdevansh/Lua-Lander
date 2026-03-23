using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingUI : MonoBehaviour
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

    public void RestartGame()
    {
        // First click → skip animation
        if (isTyping)
        {
            StopAllCoroutines();
            textUI.text = fullText;
            isTyping = false;
            return;
        }

        // Second click → restart game
        SceneManager.LoadScene("StartScene"); // or Level1 if you want direct restart
    }
}