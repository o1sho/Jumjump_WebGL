using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckOnPlatform : MonoBehaviour
{
    public static Action scoreUp;
    public static Action scoreSuperUp;
    public static Action stopMove;
    public static Action spawnNewPlatform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "DefaultPlatform":
                    scoreUp?.Invoke();
                    stopMove?.Invoke();
                    spawnNewPlatform?.Invoke();
                    gameObject.SetActive(false);
                    break;
                case "2xPlatform":
                    scoreSuperUp?.Invoke();
                    stopMove?.Invoke();
                    spawnNewPlatform?.Invoke();
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
