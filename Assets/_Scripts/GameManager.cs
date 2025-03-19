﻿using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private static int score=0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private TextMeshProUGUI scoreText;
   

    private int currentBrickCount;
    private int totalBrickCount;





    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here
        // implement particle effect here
        // add camera shake here
        currentBrickCount--;
        IncreaseScore();
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");

        if(currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        ball.ResetBall();
    }

    public void IncreaseScore()
    {
    score++;
    if (coinCounter != null)
    {
        coinCounter.UpdateScore(score);
    }
    else
    {
        Debug.LogError("coinCounter is null! Make sure it's assigned in the Inspector or initialized correctly.");
    }
}

}
