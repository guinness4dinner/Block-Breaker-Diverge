using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    
    [SerializeField] int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockBreak = 72;
    public bool hasStarted = false;
    [SerializeField] int currentScore = 0;

    SceneLoader sceneLoader;
    Canvas pauseMenu;
    Ball ball1;
    Paddle paddle1;
    float gameSpeedBeforePause;

    private void Awake ()
    {
        int countGameMangers = FindObjectsOfType<GameManager>().Length;
        if (countGameMangers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    // Use this for initialization
    void Start () 
    {       
        ball1 = FindObjectOfType<Ball>();
        paddle1 = FindObjectOfType<Paddle>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        pauseMenu = GameObject.Find("UI Manager/Pause Menu Canvas").GetComponent<Canvas>();
        livesText.text = "Paddles: " + lives.ToString();
        scoreText.text = "Score: " + currentScore.ToString();
    }
	
	// Update is called once per frame
	void Update () 
    {
        Time.timeScale = gameSpeed;
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
            ResetBallToPaddle();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenu.enabled)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void GameOver()
    {
        Cursor.visible = true;
        sceneLoader.LoadGameOver();
    }

    private void LostPaddle()
    {
        lives--;
        livesText.text = "Paddles: " + lives.ToString();
    }

    private void ResetBallToPaddle()
    {
        paddle1.enableMovement = false;
        ball1.GetComponent<Rigidbody2D>().Sleep();
        hasStarted = false;
        ball1.MoveBallToPaddle();
        ball1.GetComponent<Rigidbody2D>().WakeUp();
        paddle1.enableMovement = true;
    }


    private void PauseGame()
    {
        pauseMenu.enabled = true;
        gameSpeedBeforePause = gameSpeed;
        paddle1.enableMovement = false;
        Cursor.visible = true;
        gameSpeed = 0f;
    }

    private void ResumeGame()
    {
        pauseMenu.enabled = false;
        paddle1.enableMovement = true;
        Cursor.visible = false;
        gameSpeed = gameSpeedBeforePause;
    }
}
