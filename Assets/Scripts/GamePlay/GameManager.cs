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

    //[SerializeField] private int levelNumber;
    //private static int levelNumber = 1;
    //private static int totalScore = 0;

    [SerializeField] private PopUpUI popUpUI;
    //[SerializeField] private GameObject landingPadBlinker;
    [SerializeField] private TextMeshProUGUI objectiveText;

    private bool rareItemCollected = false;
    private bool playerLanded;

    //public static void ResetStaticData()
    //{
    //    levelNumber = 1;
    //    totalScore = 0;
    //}

    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    //[SerializeField] private List<GameLevel> gameLevelList;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    public object landerRigidBody2D { get; private set; }

    //private int score;
    //private float time;
    private bool isTimerActive;
    private void Awake()
    {
        Instance = this;
    }
    private void Start(){
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
            cinemachineCamera.Target.TrackingTarget = Lander.Instance.transform;
            CinemachineCameraZoom2D.Instance.SetNormalTargetOrthographicSize();
        }
    }

    //private void Update()
    //{
    //    if (isTimerActive){
    //        time += Time.deltaTime;
    //    }
    //}
    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        //AddScore(e.score);
        ScoreManager.Instance.AddScore(e.score);

        if (rareItemCollected)
        {
            objectiveText.gameObject.SetActive(false);
            ScoreManager.Instance.AddToTotalScore();
            //LevelManager.Instance.GoToNextLevel();   
        }

        //playerLanded = true;
        //CheckWinCondition();
    }

    private void Lander_OnCoinPickup(object sender, System.EventArgs e){
        //AddScore(500); 
        ScoreManager.Instance.AddScore(500);
    }


    //private void LoadCurrentLevel(){
    //    GameLevel gameLevel = GetGameLevel();
    //    GameLevel spawnedGameLevel = Instantiate(gameLevel, Vector3.zero, Quaternion.identity);
    //    Lander.Instance.transform.position = spawnedGameLevel.GetLanderStartPosition();
    //    cinemachineCamera.Target.TrackingTarget = spawnedGameLevel.GetCameraStartTargetTransform();
    //    CinemachineCameraZoom2D.Instance.SetTargetOrthographicSize(spawnedGameLevel.GetZoomOutOrthographSize());
    //}

    //private GameLevel GetGameLevel(){
    //    foreach(GameLevel gameLevel in gameLevelList){ 
    //        if(gameLevel.GetLevelNumber() == levelNumber){
    //            return gameLevel;
    //            //GameLevel spawnedGameLevel = Instantiate(gameLevel, Vector3.zero, Quaternion.identity);
    //            //Lander.Instance.transform.position = spawnedGameLevel.GetLanderStartPosition();
    //            //cinemachineCamera.Target.TrackingTarget = spawnedGameLevel.GetCameraStartTargetTransform();
    //            //CinemachineCameraZoom2D.Instance.SetTargetOrthographicSize(spawnedGameLevel.GetZoomOutOrthographSize());
    //        }
    //    }
    //    return null;
    //}
    //public void AddScore(int addScoreAmount){
    //    score += addScoreAmount;
    //    Debug.Log(score);
    //}

    //public int GetScore(){
    //    return score;
    //}
    //public float GetTime(){
    //    return time;
    //}

    //public int GetLevelNumber()
    //{
    //    return levelNumber;
    //}

    //public int GetTotalScore()
    //{
    //    return totalScore;
    //}
    //public void GoToNextLevel()
    //{
    //    levelNumber++;
    //    totalScore += score;    
    //    //SceneManager.LoadScene(0);

    //    if(GetGameLevel() == null)
    //    {
    //        // no more levels
    //        SceneLoader.LoadScene(SceneLoader.Scene.GameOverScene);
    //    }
    //    else
    //    {
    //        // We Still have more levels
    //        SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
    //    }
    //}

    public void RareItemCollected()
    {

        rareItemCollected = true;
        Debug.Log("Rare item Collected!");
        ScoreManager.Instance.AddScore(2000); // Bouns Score

        //landingPadBlinker.SetActive(true);

        //if (landingPadBlinker != null)
        //    landingPadBlinker.SetActive(true);

        objectiveText.gameObject.SetActive(true);
        objectiveText.text = "RETURN TO LANDING PAD";

        //CheckWinCondition();
        //LevelManager.Instance.GoToNextLevel();
    }

    //void CheckWinCondition()
    //{
    //    if (rareItemCollected && playerLanded)
    //    {
    //        LevelManager.Instance.GoToNextLevel();
    //    }
    //}

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
