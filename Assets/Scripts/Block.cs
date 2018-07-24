﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] Sprite[] blockBroken;
    int currentBlockIndex = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentBlockIndex > blockBroken.Length - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = blockBroken[currentBlockIndex];
                currentBlockIndex++;
            }
    }
}
