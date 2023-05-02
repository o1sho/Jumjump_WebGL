using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckOnStartPlatform : MonoBehaviour
{
    public static Action spawnNewPlatform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spawnNewPlatform?.Invoke();
            gameObject.SetActive(false);
        }
    }
}