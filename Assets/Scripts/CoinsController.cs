using TMPro;
using UnityEngine;
using System;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    public static int coins;

    private void OnEnable()
    {
        PlayerCheckOnCoin.coinAdd += AddCoin;
        PlayerController.saveEarnedCoins += SaveEarnedCoins;
        BuyNewPlayerController.saveEarnedCoins += SaveEarnedCoins;
    }

    private void OnDisable()
    {
        PlayerCheckOnCoin.coinAdd -= AddCoin;
        PlayerController.saveEarnedCoins -= SaveEarnedCoins;
        BuyNewPlayerController.saveEarnedCoins -= SaveEarnedCoins;
    }

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void Update()
    {
        _coinsText.text = coins.ToString();

        //if (Input.GetKeyDown(KeyCode.C)) coins += 100;
    }

    public static void AddCoin()
    {
        coins++;
    }

    public void SaveEarnedCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }
}
