using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private int totalLevels = 10;
    [SerializeField] private Sprite[] artifactSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 1; i <= totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            int levelIndex = i;

            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            Button button = buttonObj.GetComponent<Button>();

            if (i > unlockedLevel)
            {
                button.interactable = false;
            }

            // ⭐ NEW PART (artifact check)
            Transform artifactIcon = buttonObj.transform.Find("ArtifactIcon");

            if (artifactIcon != null)
            {
                Image iconImage = artifactIcon.GetComponent<Image>();

                bool collected = PlayerPrefs.GetInt("Level_" + levelIndex, 0) == 1;
                if(levelIndex -1 < artifactSprites.Length)
                {
                    iconImage.sprite = artifactSprites[levelIndex-1];
                }
                //iconImage.color = collected ? Color.white : Color.gray;
                iconImage.color = collected ? Color.white : new Color(1, 1, 1, 0.3f);
                iconImage.transform.localScale = collected ? Vector3.one : Vector3.one * 0.8f;
            }

            button.onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("SelectedLevel", levelIndex);
                SceneLoader.LoadScene(SceneLoader.Scene.GameScene);
            });
        }
    }

    public void OnBackButtonPressed()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
    }
}
