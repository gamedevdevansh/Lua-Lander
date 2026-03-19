//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using System;
using UnityEngine.UIElements;
using TMPro;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UnityEngine.UI.Image artifactIcon;

    [SerializeField] private PopUpUI popUpUI;
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private TextMeshProUGUI tapToPlayText;

    private bool rareItemCollected = false;
    private bool playerLanded;

    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    public object landerRigidBody2D { get; private set; }

    private bool isTimerActive;
    private void Awake()
    {
        Instance = this;
    }
    private void Start(){
        tapToPlayText.gameObject.SetActive(true);

        Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
        Lander.Instance.OnLanded += Lander_OnLanded;
        Lander.Instance.OnStateChanged += Lander_OnStateChanged;

        GameInput.Instance.OnMenuButtonPressed += GameInput_OnMenuButtonPressed;
        //LoadCurrentLevel();
    }

    private void GameInput_OnMenuButtonPressed(object sender, System.EventArgs e)
    {
        PauseUnpauseGame();
    }

    private void Lander_OnStateChanged(object sender, Lander.OnStateChangedEventArgs e)
    {
        isTimerActive = e.state == Lander.State.Normal;

        if (e.state == Lander.State.Normal) {
            tapToPlayText.gameObject.SetActive(false);
            cinemachineCamera.Target.TrackingTarget = Lander.Instance.transform;
            CinemachineCameraZoom2D.Instance.SetNormalTargetOrthographicSize();
        }
    }

    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * 2f, 1f);

        if (tapToPlayText.gameObject.activeSelf)
        {
            Color color = tapToPlayText.color;
            color.a = alpha;
            tapToPlayText.color = color;
        }

        if (objectiveText.gameObject.activeSelf)
        {
            Color color = objectiveText.color;
            color.a = alpha;
            objectiveText.color = color;
        }
    }

    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        ScoreManager.Instance.AddScore(e.score);

        if (rareItemCollected)
        {
            objectiveText.gameObject.SetActive(false);
            ScoreManager.Instance.AddToTotalScore(); 
        }
    }

    private void Lander_OnCoinPickup(object sender, System.EventArgs e){ 
        ScoreManager.Instance.AddScore(500);
    }

    public void RareItemCollected()
    {

        rareItemCollected = true;
        Debug.Log("Rare item Collected!");
        ScoreManager.Instance.AddScore(2000); // Bouns Score

        objectiveText.gameObject.SetActive(true);
        objectiveText.text = "RETURN TO LANDING PAD";

    }

    public void RetryLevel()
    {
        //SceneManager.LoadScene(0);
        SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
    }

    public void PauseUnpauseGame()
    {
        if (Time.timeScale == 1f)
        {
            PauseGame();
        }else
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        OnGamePaused?.Invoke(this, EventArgs.Empty);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f; 
        OnGameUnpaused?.Invoke(this, EventArgs.Empty);
    }

}
