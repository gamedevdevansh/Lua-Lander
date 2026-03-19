using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] private List<GameLevel> gameLevelList;
    private int currentLevelNumber;
    private const string LEVEL_KEY = "UnlockedLevel";

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        int selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 1);
        if(selectedLevel != -1)
        {
            currentLevelNumber = selectedLevel;
        }
        else
        { 
            currentLevelNumber = PlayerPrefs.GetInt(LEVEL_KEY, 1);
        }
        LoadCurrentLevel();

        //int level = LevelManager.Instance.GetCurrentLevelNumber();

        //if (IsArtifactCollected(level))
        //{
        //    artifactIcon.color = Color.white;
        //}
        //else
        //{
        //    artifactIcon.color = Color.gray;
        //}
    
}

    private void LoadCurrentLevel()
    {
        GameLevel level = GetLevelByNumber(currentLevelNumber);

        if (level == null)
        {
            Debug.LogError("Level not found");
            return;
        }

        GameLevel spawnedLevel = Instantiate(level, Vector3.zero, Quaternion.identity);

        Lander.Instance.transform.position = spawnedLevel.GetLanderStartPosition();
        CinemachineCameraZoom2D.Instance.SetTargetOrthographicSize(spawnedLevel.GetZoomOutOrthographSize());
    }

    public GameLevel GetLevelByNumber(int number)
    {
        foreach(GameLevel level in gameLevelList)
        {
            if (level.GetLevelNumber() == number)
                return level;
        }
        return null;
    }

    public void GoToNextLevel()
    {
        int nextLevel = currentLevelNumber + 1;

        if(GetLevelByNumber(nextLevel) != null)
        {
            currentLevelNumber = nextLevel;
            PlayerPrefs.SetInt(LEVEL_KEY, nextLevel);
            PlayerPrefs.Save();
            SceneLoader.LoadScene(SceneLoader.Scene.LevelScene);
        }
        else
        {
            SceneLoader.LoadScene(SceneLoader.Scene.GameOverScene);
        }
    }

    public int GetCurrentLevelNumber()
    {
        return currentLevelNumber;
    }
}

