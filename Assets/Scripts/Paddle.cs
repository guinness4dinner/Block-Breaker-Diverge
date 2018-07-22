using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] LevelManager levelManager;
    [SerializeField] float screenWidthInUnits = 21.333333f;
    [SerializeField] float paddleMinClamp = 5f;
    [SerializeField] float paddleMaxClamp = 19f;
    [SerializeField] AudioSource paddleHitSound;
    public bool enableMovement = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enableMovement)
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Debug.Log(mousePosInUnits);
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, paddleMinClamp, paddleMaxClamp);
            transform.position = paddlePos;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball") == true && levelManager.GetComponent<LevelManager>().hasStarted)
        {
            paddleHitSound.Play();
        }
    }
}
