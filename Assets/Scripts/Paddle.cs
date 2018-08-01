using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 21.333333f;
    [SerializeField] float paddleMinClampNormal = 1f;
    [SerializeField] float paddleMaxClampNormal = 15f;
    [SerializeField] float paddleMinClampNarrow = 0.71f;
    [SerializeField] float paddleMaxClampNarrow = 15.31f;
    [SerializeField] float paddleMinClampExt = 1.4f;
    [SerializeField] float paddleMaxClampExt = 14.59f;
    [SerializeField] Sprite[] paddleSprites;
    public bool enableMovement = true;

    float paddleMinClamp;
    float paddleMaxClamp;

    private void Start()
    {
        paddleMinClamp = paddleMinClampNormal;
        paddleMaxClamp = paddleMaxClampNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if (enableMovement)
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, paddleMinClamp, paddleMaxClamp);
            transform.position = paddlePos;
        }

    }

    public void ExtendPaddle()
    {
        EdgeCollider2D[] colliders = GetComponents<EdgeCollider2D>();
        colliders[0].enabled = false;
        colliders[1].enabled = true;
        colliders[2].enabled = false;
        GetComponent<SpriteRenderer>().sprite = paddleSprites[1];
        paddleMinClamp = paddleMinClampExt;
        paddleMaxClamp = paddleMaxClampExt;
    }

    public void NarrowPaddle()
    {
        EdgeCollider2D[] colliders = GetComponents<EdgeCollider2D>();
        colliders[0].enabled = false;
        colliders[1].enabled = false;
        colliders[2].enabled = true;
        GetComponent<SpriteRenderer>().sprite = paddleSprites[2];
        paddleMinClamp = paddleMinClampNarrow;
        paddleMaxClamp = paddleMaxClampNarrow;
    }

    public void NormalPaddle()
    {
        EdgeCollider2D[] colliders = GetComponents<EdgeCollider2D>();
        colliders[0].enabled = true;
        colliders[1].enabled = false;
        colliders[2].enabled = false;
        GetComponent<SpriteRenderer>().sprite = paddleSprites[0];
        paddleMinClamp = paddleMinClampNormal;
        paddleMaxClamp = paddleMaxClampNormal;
    }
}
