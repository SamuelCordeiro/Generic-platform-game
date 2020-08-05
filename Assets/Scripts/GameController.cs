using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public GameObject gameOver;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreTextUpdate()
    {
        Save();
        scoreText.text = totalScore.ToString();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("x", totalScore);
    }
    public void Load()
    {
        totalScore = PlayerPrefs.GetInt("x");
        ScoreTextUpdate();
    }
    public void ShowGameOver()
    {
       gameOver.SetActive(true);

    }

    public void StartGame(string levelName)
    {
        SceneManager.LoadScene("Level 1");
        totalScore = 0;
        Save();
    }

    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
