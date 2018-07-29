using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    
    [SerializeField] int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockBreak = 72;
    [SerializeField] int currentScore = 0;
    static GameSession instance = null;

    SceneLoader sceneLoader;
    LevelManager levelManager;

    private void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update () 
    {
        Time.timeScale = gameSpeed;
	}

    public void StartLevel()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        levelManager = FindObjectOfType<LevelManager>();
        livesText.text = "Paddles: " + lives.ToString();
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void IncreaseScore()
    {
        currentScore += pointsPerBlockBreak;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void LostBall()
    {
        if (lives == 1)
        {
            GameOver();
        }
        else
        {
            LostPaddle();
            levelManager.ResetBallToPaddle();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void GameOver()
    {
        Cursor.visible = true;
        TurnOffLivesText();
        sceneLoader.LoadGameOver();
    }

    private void LostPaddle()
    {
       
        lives--;
        livesText.text = "Paddles: " + lives.ToString();
    }

    public void TurnOffLivesText()
    {
        livesText.enabled = false;
    }

}

