using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language instance { get; private set; }

    public string currentLanguage;

    [DllImport("__Internal")]
    private static extern string GetLang();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            currentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
