using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerScoreText;

    private int score;

    private void Start()
    {
        LoadScore();
        ChangeScoreText();
    }
    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("PlayerScore")) score = PlayerPrefs.GetInt("PlayerScore");
    }

    private void ChangeScoreText()
    {
        _playerScoreText.text = $"Количество очков: {score}";
    }
}
