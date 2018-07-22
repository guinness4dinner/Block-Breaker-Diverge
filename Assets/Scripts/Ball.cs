using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Config params
    [SerializeField] Paddle paddle1;
    [SerializeField] LevelManager levelManager;
    [SerializeField] float xPaddleOffsetStart = 0f;
    [SerializeField] float yPaddleOffsetStart = 0.7f;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    //state
    Vector2 ballStartPos;
    Vector2 paddleToBallVector;



	// Use this for initialization
	void Start ()
    {
        MoveBallToPaddle();
    }

    public void MoveBallToPaddle()
    {
        ballStartPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y) + new Vector2(xPaddleOffsetStart, yPaddleOffsetStart);
        transform.position = ballStartPos;
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!levelManager.GetComponent<LevelManager>().hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        } 
    }

    private void LaunchOnMouseClick()
    {
       if (Input.GetMouseButtonDown(0))
       {
            levelManager.GetComponent<LevelManager>().hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush); 
       }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
