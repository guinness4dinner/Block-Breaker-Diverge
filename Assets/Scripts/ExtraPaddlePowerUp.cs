using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPaddlePowerUp : MonoBehaviour {

    GameSession gameSession;
    float speedIncrease = 25f;

    private void Start()
    {
        gameSession = GameSession.instance;
    }

    public void Activate()
    {
        gameSession.IncreaseLives();
    }
}
