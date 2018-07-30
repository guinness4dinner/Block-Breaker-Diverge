using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] Sprite[] blockBroken;
    int currentBlockIndex = 0;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentBlockIndex > blockBroken.Length - 1)
        {
            FindObjectOfType<GameSession>().IncreaseScore();
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
