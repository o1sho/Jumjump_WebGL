using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    public static int score;

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
        score = 0;
        _scoreText.text = "0";
    }

    private void Update()
    {
        if (Database.instance.GetMaxScore() < score) Database.instance.SetMaxScore(score);
        _maxScoreText.text = Database.instance.GetMaxScore().ToString();
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
        Database.instance.SaveGameData();
#if !UNITY_EDITOR && UNITY_WEBGL
        LeaderBoard(Database.instance.GetMaxScore());
#endif
    }
}
