//using TMPro;
//using UnityEngine;

//public class PopUpUI : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI popupText;
//    private float timer;
//    private float showTime = 1f;
//    void Update()
//    {
//        if (popupText.gameObject.activeSelf)
//        {
//            timer -= Time.deltaTime;
//            if(timer <= 0f)
//            {
//                popupText.gameObject.SetActive(false);
//            }
//        }
//    }

//    public void ShowPopup(int amount)
//    {
//        popupText.text = "+" + amount;
//        popupText.gameObject.SetActive(true);
//        timer = showTime;
//    }   
//}
using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupText;

    private float timer;
    private float showTime = 1f;

    private float fadeSpeed = 3f;

    void Update()
    {
        if (popupText.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;

            Color color = popupText.color;

            if (timer > showTime * 0.5f)
            {
                // Fade In
                color.a += fadeSpeed * Time.deltaTime;
            }
            else
            {
                // Fade Out
                color.a -= fadeSpeed * Time.deltaTime;
            }

            popupText.color = color;

            if (timer <= 0f)
            {
                popupText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowPopup(int amount)
    {
        popupText.text = "+" + amount;

        Color color = popupText.color;
        color.a = 0f;
        popupText.color = color;

        popupText.gameObject.SetActive(true);

        timer = showTime;
    }
}