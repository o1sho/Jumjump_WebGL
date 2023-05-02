using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private int _direction;
    public float _moveSpeed;

    public static Action setRightPlayer;
    public static Action setLeftPlayer;

    private void OnEnable()
    {
        PlayerCheckOnPlatform.stopMove += StopMove;
    }

    private void OnDisable()
    {
        PlayerCheckOnPlatform.stopMove -= StopMove;
    }

    private void Awake()
    {
        _direction = transform.position.x < 0 ? 1 : -1;
    }

    private void Start()
    {
        if (_direction == 1)
        {
            setLeftPlayer?.Invoke();
        } else if (_direction == -1) setRightPlayer?.Invoke();
    }

    private void Update()
    {
        float speed = TimeController.instance._gameSpeed / _moveSpeed;
        transform.position += Vector3.right * _direction * speed * Time.deltaTime;
    }

    private void StopMove()
    {
        _direction= 0;
    }
}
