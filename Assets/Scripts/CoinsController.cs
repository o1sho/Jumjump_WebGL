using TMPro;
using UnityEngine;
using System;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;



    private void Update()
    {
        _coinsText.text = Database.instance.GetCoins().ToString();

        //if (Input.GetKeyDown(KeyCode.C)) coins += 100;
    }

    public static void AddCoin(int count)
    {
        Database.instance.SetCoins(count);
    }

}
