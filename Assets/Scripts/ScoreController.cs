using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    public static int score;
    private int _maxScore;

    [DllImport("__Internal")]
    private static extern void LeaderBoard(int maxScore);

    private void OnEnable()
    {
        PlayerCheckOnPlatform.scoreUp += ScoreUp;
        PlayerCheckOnPlatform.scoreSuperUp += ScoreSuperUp;
        PlayerController.saveMaxScore += SaveMaxScore;
    }

    private void OnDisable()
    {
        PlayerCheckOnPlatform.scoreUp -= ScoreUp;
        PlayerCheckOnPlatform.scoreSuperUp -= ScoreSuperUp;
        PlayerController.saveMaxScore -= SaveMaxScore;
    }

    private void Start()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore");
        score = 0;
        _scoreText.text = "0";
    }

    private void Update()
    {
        if (_maxScore < score) _maxScore= score;
        _maxScoreText.text = _maxScore.ToString();
        _scoreText.text = score.ToString();  
    }

    public static void ScoreUp()
    {
        score++;
    }

    public static void ScoreSuperUp()
    {
        score*=2;
    }

    public void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", _maxScore);
        LeaderBoard(PlayerPrefs.GetInt("MaxScore"));
    }
}
