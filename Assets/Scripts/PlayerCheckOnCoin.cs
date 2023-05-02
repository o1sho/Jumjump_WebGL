using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckOnCoin : MonoBehaviour
{
    public static Action coinAdd;

    public static Action soundCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coinAdd?.Invoke();
            Destroy(gameObject);
            soundCoin?.Invoke();
        }
    }
}
