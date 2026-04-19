using UnityEngine;
using TMPro;

public class ScoreeManager : MonoBehaviour
{
    public static ScoreeManager instance;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private int score = 0;
    private int bestScore = 0;
    private float timer = 0f;

    private bool isGameOver = false;

    private void Awake()
    {
        instance = this;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateUI();
    }

    private void Update()
    {
        if (isGameOver) return;

        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            AddScore(1);
            timer = 0f;
        }
    }

    public void AddScore(int amount = 1)
    {
        score += amount;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        UpdateUI();
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (bestScoreText != null)
            bestScoreText.text = "Best: " + bestScore;
    }
}