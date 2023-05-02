using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance { get; private set; }

    public float _gameSpeed;
    public float _speedIncrease;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else Destroy(gameObject);
    }

    private void Update()
    {
        _gameSpeed += _speedIncrease * Time.deltaTime;
    }

    public void SetDefaulttGameSpeed()
    {
        _gameSpeed = 6f;
    }
}
