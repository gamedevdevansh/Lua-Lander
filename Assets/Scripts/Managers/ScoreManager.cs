using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private PopUpUI popUpUI;


    private int score;
    private int totalScore;
    private float time;
    private bool isTimerActive;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void StartTimer()
    {
        isTimerActive = true;
    }

    public void StopTimer()
    {
        isTimerActive = false;
    }

    public void AddScore(int amount)
    {
        score += amount;
        popUpUI.ShowPopup(amount);
        Debug.Log(score);
    }

    public int GetScore() => score;
    public float GetTime() => time;


    public void AddToTotalScore()
    {
        totalScore += score;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
    public void ResetScore()
    {
        score = 0;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
            time += Time.deltaTime;
    }

}
