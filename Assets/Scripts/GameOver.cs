using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] public Button continueButton;
    [SerializeField] public int continuePriseCoins;

    //ADV Yandex
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    [DllImport("__Internal")]
    private static extern void ShowRewardAdv();

    private void OnEnable()
    {
        Time.timeScale = 0f;
        ShowAdv();
        if (CoinsController.coins >= continuePriseCoins)
        {
            continueButton.interactable = true;
        } else if (CoinsController.coins < continuePriseCoins) continueButton.interactable = false;

        
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;

    }

    public void RewardAdv()
    {
        ShowRewardAdv();
    }

    public void PickUpCoin()
    {
        CoinsController.coins -= continuePriseCoins;
    }
}
