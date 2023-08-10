using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckOnCoin : MonoBehaviour
{
    public static Action soundCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Coin":
                    CoinsController.AddCoin(+1);
                    break;
                case "Bag":
                    CoinsController.AddCoin(+20);
                    break;
            }

            Destroy(gameObject);
            soundCoin?.Invoke();
        }
    }
}
