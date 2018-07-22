using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour 
{
    [SerializeField] GameObject levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.GetComponent<LevelManager>().lostBall = true;
    }

}
