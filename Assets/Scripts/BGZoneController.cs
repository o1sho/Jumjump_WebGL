using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGZoneController : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
        } else
        {
            panel1.SetActive(true);
            panel2.SetActive(true);
        }
    }
}
