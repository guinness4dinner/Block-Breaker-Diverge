using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour {

    GameManager gameManager;
    //SoundManager soundManager;

    
	// Use this for initialization
	void Start () 
    {
        gameManager = FindObjectOfType<GameManager>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        ScanForKeyStroke();
	}

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.TogglePauseMenu();
        }
    }
}
