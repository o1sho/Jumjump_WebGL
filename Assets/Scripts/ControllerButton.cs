using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButton : MonoBehaviour
{
    public void Jump()
    {
        PlayerController.Instance.Jump();
        Debug.Log("TapJump");
    }
}
