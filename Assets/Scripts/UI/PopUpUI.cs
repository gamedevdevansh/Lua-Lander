using TMPro;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popupText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float timer;
    private float showTime = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (popupText.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                popupText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowPopup(int amount)
    {
        popupText.text = "+" + amount;
        popupText.gameObject.SetActive(true);
        timer = showTime;
    }   
}
