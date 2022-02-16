using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] public bool gameRunning;
    public static GameManager Instance { get; private set; }
    private float timeToNextGame = 5;

    private int score = 0;
   

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        gameRunning = true;
        gameOverDisplay.text = "";
        score = 0;
    }

    public void ScorePoint()
    {
        score++;
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        gameRunning = false;
        gameOverDisplay.text = $"Score: {score}";
        Invoke("ResetGame", timeToNextGame);

    }


}
