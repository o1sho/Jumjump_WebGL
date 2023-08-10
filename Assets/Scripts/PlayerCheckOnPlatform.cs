using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCheckOnPlatform : MonoBehaviour
{
    public static Action stopMove;
    public static Action spawnNewPlatform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "DefaultPlatform":
                    ScoreController.instance.ScoreUp();
                    stopMove?.Invoke();
                    spawnNewPlatform?.Invoke();
                    gameObject.SetActive(false);
                    break;
                case "2xPlatform":
                    ScoreController.instance.ScoreSuperUp();
                    stopMove?.Invoke();
                    spawnNewPlatform?.Invoke();
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
