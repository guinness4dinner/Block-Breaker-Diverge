using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 21.333333f;
    [SerializeField] float paddleMinClamp = 5f;
    [SerializeField] float paddleMaxClamp = 19f;
    public bool enableMovement = true;


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
}
