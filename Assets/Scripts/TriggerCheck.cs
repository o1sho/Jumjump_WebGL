using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCheck : MonoBehaviour
{
    [SerializeField] public string triggerTag;

    public static Action isGameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerTag)
        {
            isGameOver?.Invoke();
        }
    }
}
