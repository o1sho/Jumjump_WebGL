using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    private void OnEnable()
    {
        PlayerController.isGameOver += isGameOver;
        TriggerCheck.isGameOver += isGameOver;
    }

    private void OnDisable()
    {
        PlayerController.isGameOver -= isGameOver;
        TriggerCheck.isGameOver -= isGameOver;
    }

    public void isGameOver()
    {
        gameOver.SetActive(true);
    }
}
