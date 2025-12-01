using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start ()
    {
        ScoreText.text = "Final Score: " + ScoreManager.score.ToString();
    }
    public void Retry()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
