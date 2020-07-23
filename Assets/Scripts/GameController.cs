using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreTextUpdate()
    {
        scoreText.text = totalScore.ToString();
    }
}
