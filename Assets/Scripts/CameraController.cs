using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        _camera.Follow = GameObject.FindWithTag("Player").transform;
    }
}
