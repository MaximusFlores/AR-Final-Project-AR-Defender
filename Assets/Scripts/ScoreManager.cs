using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    // This "Singleton" pattern makes it easy to access this script from anywhere
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText; // Drag your UI Text here
    private int score = 0;

    void Awake()
    {
        // Set up the singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}