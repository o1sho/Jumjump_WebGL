using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationCharacterController : MonoBehaviour
{
    [SerializeField] public GameObject[] playersPrefab;

    private void Start()
    {
        Instantiate(playersPrefab[PlayerPrefs.GetInt("idActiveCharacter")]);
    }
}
