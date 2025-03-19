using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [Header("Hearts and Game Over")]
    [SerializeField] private List<GameObject>hearts;
    [SerializeField] private GameObject gameOver;

    private int currentBrickCount;
    private int totalBrickCount;
    public static int health;

    private void Start()
    {
        Time.timeScale = 1.0f;
        health = 3;
        UpdateHealth();
        gameOver.gameObject.SetActive(false);
    }

    // Video reference for Heart (health) code:
    // https://www.youtube.com/watch?v=LsUiJItfzxU
    // Modularize heart code to handle any number of lives
    // first sets all active hearts to false
    // then enables them based on health count

    private void UpdateHealth()
    {
        if (health > maxLives) health = maxLives;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
           hearts[i].SetActive(true);
        }

        if (health == 0)
        {
            Time.timeScale = 0f;
            gameOver.gameObject.SetActive(true);
        }
    }

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
        GameObject explosionPrefab = Resources.Load<GameObject>("BrickExplosion");
        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        Destroy(explosion, 1f);
        // add camera shake here
        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if (currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }
    public void KillBall()
    {
        health--;
        // update lives on HUD here
        UpdateHealth();
        ball.ResetBall();
    }
}
