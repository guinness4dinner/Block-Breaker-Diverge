using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour {

    [SerializeField] Ball ball1;
    [SerializeField] Paddle paddle1;
    [SerializeField] GameObject win;
    [SerializeField] int lives = 2;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int breakableBlocks = 0; //serialized for debug purposes
    public bool hasStarted = false;

    // Use this for initialization
    void Start () 
    {
        livesText.text = lives.ToString();
        Cursor.visible = false;
    }



    // Update is called once per frame
    void Update () 
    {

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
            win.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void LostBall()
    {
        if (lives == 0)
        {
            Cursor.visible = true;
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            lives--;
            livesText.text = lives.ToString();
            paddle1.enableMovement = false;
            ball1.GetComponent<Rigidbody2D>().Sleep();
            hasStarted = false;
            ball1.MoveBallToPaddle();
            ball1.GetComponent<Rigidbody2D>().WakeUp();
            paddle1.enableMovement = true;
        }
    }
}
