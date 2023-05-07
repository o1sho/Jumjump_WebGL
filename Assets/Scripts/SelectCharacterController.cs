using System;
using UnityEngine;


public class SelectCharacterController : MonoBehaviour
{
    public static SelectCharacterController Instance;

    [Serializable]
    public struct Characters
    {
        public GameObject character;
        public bool buyed;
        public int price;
    }
    public Characters[] characters;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    private void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == Database.Instance.characterActiveID)
            {
                characters[i].character.SetActive(true);
            }

            if (Database.Instance.characterBuyedID.Contains(i))
            {
                characters[i].buyed = true;
                Debug.Log("Куплены персонажи: " + i);
            }
            else characters[i].buyed = false;
        }
        characters[0].buyed = true;
        Debug.Log("Выбран персонаж: " + Database.Instance.characterActiveID);
        Debug.Log("Всего персонажей: " + characters.Length);
    }

    public void SelectRight()
    {
        if (Database.Instance.shortCharacterActiveID < characters.Length - 1)
        {
            characters[Database.Instance.shortCharacterActiveID].character.SetActive(false);
            Database.Instance.shortCharacterActiveID++;
            characters[Database.Instance.shortCharacterActiveID].character.SetActive(true);
            Debug.Log("Персонаж: " + Database.Instance.shortCharacterActiveID);
            // Проверка на купленность
            if (characters[Database.Instance.shortCharacterActiveID].buyed)
            {
                Database.Instance.characterActiveID = Database.Instance.shortCharacterActiveID;
                Database.Instance.Save();
                Debug.Log("Выбран персонаж: " + Database.Instance.characterActiveID);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("BuyPlayer").gameObject.SetActive(false);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("PriceInfo").gameObject.SetActive(false);
            }
            else
            {
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("BuyPlayer").gameObject.SetActive(true);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("PriceInfo").gameObject.SetActive(true);
            }
        }
    }

    public void SelectLeft()
    {
        if (Database.Instance.shortCharacterActiveID > 0)
        {
            characters[Database.Instance.shortCharacterActiveID].character.SetActive(false);
            Database.Instance.shortCharacterActiveID--;
            characters[Database.Instance.shortCharacterActiveID].character.SetActive(true);
            Debug.Log("Персонаж: " + Database.Instance.shortCharacterActiveID);
            // Проверка на купленность
            if (characters[Database.Instance.shortCharacterActiveID].buyed)
            {
                Database.Instance.characterActiveID = Database.Instance.shortCharacterActiveID;
                Database.Instance.Save();
                Debug.Log("Выбран персонаж: " + Database.Instance.characterActiveID);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("BuyPlayer").gameObject.SetActive(false);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("PriceInfo").gameObject.SetActive(false);
            }
            else
            {
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("BuyPlayer").gameObject.SetActive(true);
                characters[Database.Instance.shortCharacterActiveID].character.transform.Find("PriceInfo").gameObject.SetActive(true);
            }
        }
    }

    public void BuyNewCharacter()
    {
        if (Database.Instance.coins >= characters[Database.Instance.shortCharacterActiveID].price && !characters[Database.Instance.shortCharacterActiveID].buyed)
        {
            characters[Database.Instance.shortCharacterActiveID].buyed = true;
            Database.Instance.coins -= characters[Database.Instance.shortCharacterActiveID].price;
            Database.Instance.characterActiveID = Database.Instance.shortCharacterActiveID;
            Database.Instance.characterBuyedID.Add(Database.Instance.shortCharacterActiveID);
            Database.Instance.Save();
        }
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

        if (characters[Database.Instance.shortCharacterActiveID].buyed)
        {
            Database.Instance.characterActiveID = Database.Instance.shortCharacterActiveID;
            characters[Database.Instance.shortCharacterActiveID].character.transform.Find("BuyPlayer").gameObject.SetActive(false);
            characters[Database.Instance.shortCharacterActiveID].character.transform.Find("PriceInfo").gameObject.SetActive(false);
        }    
    }
}
