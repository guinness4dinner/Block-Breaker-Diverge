using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    public Ball ball1;
    public Paddle paddle1;
    [SerializeField] Canvas winCanvas;
    [SerializeField] int breakableBlocks = 0; //serialized for debug purposes
    public Canvas pauseMenu;
    public bool hasStarted = false;

    GameSession gameSession;
    SceneLoader sceneLoader;

    float gameSpeedBeforePause;

    // Use this for initialization
    void Start () 
    {
        gameSession = FindObjectOfType<GameSession>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Cursor.visible = false;
        gameSession.StartLevel();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestoyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            Destroy(ball1.GetComponent<Rigidbody2D>());
            paddle1.enableMovement = false;
            hasStarted = false;
            winCanvas.enabled = true;
            Cursor.visible = true;
            gameSession.TurnOffLivesText();
            sceneLoader.LoadNextLevel();
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

    private void PauseGame()
    {
        pauseMenu.enabled = true;
        gameSpeedBeforePause = gameSession.gameSpeed;
        paddle1.enableMovement = false;
        Cursor.visible = true;
        gameSession.gameSpeed = 0f;
    }

    private void ResumeGame()
    {
        pauseMenu.enabled = false;
        paddle1.enableMovement = true;
        Cursor.visible = false;
        gameSession.gameSpeed = gameSpeedBeforePause;
    }

    public void ResetBallToPaddle()
    {
        paddle1.enableMovement = false;
        ball1.GetComponent<Rigidbody2D>().Sleep();
        hasStarted = false;
        ball1.MoveBallToPaddle();
        ball1.GetComponent<Rigidbody2D>().WakeUp();
        paddle1.enableMovement = true;
    }

}
