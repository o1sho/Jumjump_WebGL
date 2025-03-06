using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public Button continueButton;
    [SerializeField] public int continuePriseCoins;

    public static bool isGameOver;



    private void OnEnable()
    {
        isGameOver= true;

        Time.timeScale = 0f;

        Database.instance.SaveGameData();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        isGameOver = false;
    }

}
