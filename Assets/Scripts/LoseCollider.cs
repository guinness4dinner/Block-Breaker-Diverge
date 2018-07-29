using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour 
{
    GameSession gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        gameManager.LostBall();
    }

}
