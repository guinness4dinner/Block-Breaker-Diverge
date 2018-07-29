using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour {

    [SerializeField] Ball ball1;
    [SerializeField] Paddle paddle1;
    [SerializeField] Canvas winCanvas;
    [SerializeField] int breakableBlocks = 0; //serialized for debug purposes

    GameManager gameManager;
    SceneLoader sceneLoader;

    // Use this for initialization
    void Start () 
    {
        gameManager = FindObjectOfType<GameManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        Cursor.visible = false;
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
            gameManager.hasStarted = false;
            winCanvas.enabled = true;
            Cursor.visible = true;
            sceneLoader.LoadNextLevel();
        }
    }

}
