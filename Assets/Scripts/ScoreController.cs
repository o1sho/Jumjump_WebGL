using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    public static int score;

    [SerializeField] private GameObject _scoreTextInfo;
    [SerializeField] private GameObject _scoreSuperTextInfo;


    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        PlayerController.saveMaxScore += SaveMaxScore;
    }

    private void OnDisable()
    {
        PlayerController.saveMaxScore -= SaveMaxScore;
    }

    private void Start()
    {
        score = 0;
        _scoreText.text = "0";
        _scoreTextInfo.SetActive(false);
        _scoreSuperTextInfo.SetActive(false);
    }

    private void Update()
    {
        if (Database.instance.GetMaxScore() < score) Database.instance.SetMaxScore(score);
        _maxScoreText.text = Database.instance.GetMaxScore().ToString();
        _scoreText.text = score.ToString();  
    }

    public void ScoreUp()
    {
        score++;
        StartCoroutine(AppearanceScoreUpInfo());
    }

    public void ScoreSuperUp()
    {
        score*=2;
        StartCoroutine(AppearanceScoreSuperUpInfo());
    }

    public void SaveMaxScore()
    {
        Database.instance.SaveGameData();
    }

    private IEnumerator AppearanceScoreUpInfo()
    {
        _scoreTextInfo.SetActive(true);
        yield return new WaitForSeconds(1);
        _scoreTextInfo.SetActive(false);
    }
    private IEnumerator AppearanceScoreSuperUpInfo()
    {
        _scoreSuperTextInfo.SetActive(true);
        yield return new WaitForSeconds(1);
        _scoreSuperTextInfo.SetActive(false);
    }
}
