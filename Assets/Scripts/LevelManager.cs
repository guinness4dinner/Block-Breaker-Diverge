using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    [SerializeField] Ball ball1;
    [SerializeField] Paddle paddle1;
    [SerializeField] GameObject win;
    [SerializeField] int lives = 2;
    public bool lostBall = false;

    // Use this for initialization
    void Start () 
    {

    }



    // Update is called once per frame
    void Update () 
    {
        var foundBlocks = FindObjectsOfType<Block>();
        if (foundBlocks.Length == 0)
        {
            Destroy(ball1.GetComponent<Rigidbody2D>());
            paddle1.GetComponent<Paddle>().enableMovement = false;
            win.SetActive(true);
        }

        if (lostBall == true)
        {
            Debug.Log("Lost Ball");
            if (lives == 0)
            {
                SceneManager.LoadScene("Game Over");
            }
            else 
            {
                lives--;
                paddle1.GetComponent<Paddle>().enableMovement = false;
                ball1.GetComponent<Rigidbody2D>().Sleep();
                ball1.GetComponent<Ball>().MoveBallToPaddle();
                ball1.GetComponent<Ball>().hasStarted = false;
                ball1.GetComponent<Rigidbody2D>().WakeUp();
                paddle1.GetComponent<Paddle>().enableMovement = true;
            }
            lostBall = false;
        }
	}
}
