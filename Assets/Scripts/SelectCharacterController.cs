using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterController : MonoBehaviour
{
    [Serializable]
    public struct Characters
    {
        public GameObject character;
    }
    public Characters[] characters;

    //private List<int> numberOfCharacters = new List<int>(); 
    [SerializeField] public int idActiveCharacter;

    private void Start()
    {
        //numberOfCharacters.Add(characters.Length);

        for (int i = 0; i < characters.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("idActiveCharacter"))
            {
                characters[i].character.SetActive(true);
                idActiveCharacter = i;
            }
            else characters[i].character.SetActive(false);
        }


        // idActiveCharacter = PlayerPrefs.GetInt("idActiveCharacter");
        Debug.Log("Выбран персонаж: " + PlayerPrefs.GetInt("idActiveCharacter"));
        Debug.Log("Всего персонажей: " + characters.Length);
    }

    public void SelectRight()
    {
        if (idActiveCharacter < characters.Length - 1)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (i == idActiveCharacter)
                {

                }
            }
            characters[idActiveCharacter].character.SetActive(false);
            idActiveCharacter++;
            characters[idActiveCharacter].character.SetActive(true);
            Debug.Log("pukpuk");
        }
    }

    public void SelectLeft()
    {
        if (idActiveCharacter > 0)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (i == idActiveCharacter)
                {
                    idActiveCharacter --;
                    characters[i].character.SetActive(false);
                    characters[idActiveCharacter].character.SetActive(true);
                }
            }
        }
    }

    public void SaveIdActiveCharacter()
    {
        PlayerPrefs.SetInt("idActiveCharacter", idActiveCharacter);
        Debug.Log("Выбран персонаж: " + PlayerPrefs.GetInt("idActiveCharacter"));
    }



    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetString("PlayerBuyed0", "NotBuyed");
            PlayerPrefs.SetString("PlayerBuyed1", "NotBuyed");
            PlayerPrefs.SetString("PlayerBuyed" + idActiveCharacter, "NotBuyed");
            PlayerPrefs.SetInt("idActiveCharacter", 0);
        }*/

        
    }
}
