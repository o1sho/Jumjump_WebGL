using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContinue : MonoBehaviour
{
    public static Action setDefaultPos;

    public void Continue()
    {
        setDefaultPos?.Invoke();
    }


}
