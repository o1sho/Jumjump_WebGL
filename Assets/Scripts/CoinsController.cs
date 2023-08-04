using TMPro;
using UnityEngine;
using System;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void OnEnable()
    {
        PlayerCheckOnCoin.coinAdd += AddCoin;

    }

    private void OnDisable()
    {
        PlayerCheckOnCoin.coinAdd -= AddCoin;

    }

    private void Update()
    {
        _coinsText.text = Database.instance.GetCoins().ToString();

        //if (Input.GetKeyDown(KeyCode.C)) coins += 100;
    }

    public static void AddCoin()
    {
        Database.instance.SetCoins(+1);
    }

}
