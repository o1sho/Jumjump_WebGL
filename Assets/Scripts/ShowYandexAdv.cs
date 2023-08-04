using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShowYandexAdv : MonoBehaviour
{
    //ADV Yandex
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    private void Start()
    {
#if!UNITY_EDITOR && UNITY_WEBGL
        ShowAdv();
#endif
    }
}
