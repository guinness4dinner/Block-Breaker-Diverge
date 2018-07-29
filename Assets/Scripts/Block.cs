using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] Sprite[] blockBroken;
    int currentBlockIndex = 0;

    LevelManager levelManager;
    GameSession gameManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.CountBreakableBlocks();
        gameManager = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentBlockIndex > blockBroken.Length - 1)
        {
            gameManager.IncreaseScore();
            levelManager.BlockDestoyed();
            Destroy(gameObject);
        }
            else
            {
                GetComponent<SpriteRenderer>().sprite = blockBroken[currentBlockIndex];
                currentBlockIndex++;
            }
    }
}
