using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public string playerName;
    public Text hiScoreText;
    public InputField casella;
    public static int scoreToWrite = 0;
    public static string nameToWrite = "";
    
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    
        LoadHiScore();
        hiScoreText.text = "High Score: " + nameToWrite + ": " + scoreToWrite;
    }

    public void UpdatePlayerName()
    {
        playerName = casella.text;
        Debug.Log(playerName);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class HiScore
    {
        public string name;
        public int hiScore;
    }

    public void SaveHiScore()
    {
        HiScore hiScoreInstance = new HiScore();
        hiScoreInstance.name = playerName;
        hiScoreInstance.hiScore = MainManager.scoreGlobal;

        string json = JsonUtility.ToJson(hiScoreInstance);

        File.WriteAllText(Application.persistentDataPath + "/HiScore.json", json);
    }

    public void LoadHiScore()
    {
        string path = Application.persistentDataPath + "/HiScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HiScore loadedHiScore = JsonUtility.FromJson<HiScore>(json);
            nameToWrite = loadedHiScore.name;
            scoreToWrite = loadedHiScore.hiScore;
        }
    }

}
