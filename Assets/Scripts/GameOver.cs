using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public Button continueButton;
    [SerializeField] public int continuePriseCoins;

    public static bool isGameOver;

    //ADV Yandex
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [DllImport("__Internal")]
    private static extern void ShowRewardAdv();


    private void OnEnable()
    {
        isGameOver= true;

        Time.timeScale = 0f;
        ShowAdv();

        Database.Instance.Save();
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void RewardAdv()
    {
        ShowRewardAdv();
    }

}
