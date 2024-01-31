using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public float score;
    public float transitionSpeed = 100;
    float displayScore;
    public Text scoreText;
    void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        displayScore = Mathf.MoveTowards(displayScore, score, transitionSpeed * Time.deltaTime);
        UpdateScoreDisplay();
    }
    public void IncreaseScore(float amount)
    {
        score += amount;
    }
    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("Score: {0:00000}", displayScore);
    }
}