using TMPro;
using UnityEngine;
using System;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void OnEnable()
    {
        PlayerCheckOnCoin.coinAdd += AddCoin;
        PlayerController.saveEarnedCoins += SaveEarnedCoins;
    }

    private void OnDisable()
    {
        PlayerCheckOnCoin.coinAdd -= AddCoin;
        PlayerController.saveEarnedCoins -= SaveEarnedCoins;
    }

    private void Update()
    {
        _coinsText.text = Database.Instance.coins.ToString();

        //if (Input.GetKeyDown(KeyCode.C)) coins += 100;
    }

    public static void AddCoin()
    {
        Database.Instance.coins++;
    }

    public void SaveEarnedCoins()
    {
        Database.Instance.Save();
    }
}
