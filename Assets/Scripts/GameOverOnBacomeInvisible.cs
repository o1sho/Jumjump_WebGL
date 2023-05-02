using Unity.VisualScripting;
using UnityEngine;

public class GameOverOnBacomeInvisible : MonoBehaviour
{
    private MovePlatform _movePlatform;

    private void OnEnable()
    {
        _movePlatform= GetComponent<MovePlatform>();
    }

    private void OnBecameInvisible()
    {
        if (_movePlatform.enabled == false) Destroy(gameObject);
    }
}
