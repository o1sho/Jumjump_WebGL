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
            if (i == Database.instance.GetCharacterActiveID())
            {
                characters[i].character.SetActive(true);
            }

            if (Database.instance.CheckCharacterBuyedID(i))
            {
                characters[i].buyed = true;
                Debug.Log("Куплены персонажи: " + i);
            }
            else characters[i].buyed = false;
        }
        characters[0].buyed = true;
        Debug.Log("Выбран персонаж: " + Database.instance.GetCharacterActiveID());
        Debug.Log("Всего персонажей: " + characters.Length);
    }

    public void SelectRight()
    {
        SelectCharacter(+1);
    }

    public void SelectLeft()
    {
        SelectCharacter(-1);
    }

    public void BuyNewCharacter()
    {
        if (Database.instance.GetCoins() >= characters[Database.instance.GetShortCharacterActiveID()].price && !characters[Database.instance.GetShortCharacterActiveID()].buyed)
        {
            characters[Database.instance.GetShortCharacterActiveID()].buyed = true;
            Database.instance.SetCoins(- characters[Database.instance.GetShortCharacterActiveID()].price);
            Database.instance.SetCharacterActiveID(Database.instance.GetShortCharacterActiveID());
            Database.instance.SetCharacterBuyedID(Database.instance.GetShortCharacterActiveID());
            Database.instance.SaveGameData();
        }
    }


    private void Update()
    {
        if (characters[Database.instance.GetShortCharacterActiveID()].buyed)
        {
            Database.instance.SetCharacterActiveID(Database.instance.GetShortCharacterActiveID());
            ControlUIBuyInfo(false);
        }    
    }

    private void ControlUIBuyInfo(bool action)
    {
        characters[Database.instance.GetShortCharacterActiveID()].character.transform.Find("BuyPlayer").gameObject.SetActive(action);
        characters[Database.instance.GetShortCharacterActiveID()].character.transform.Find("PriceInfo").gameObject.SetActive(action);
    }

    private void SelectCharacter(int side)
    {
        if (side == 1)
        {
            if (Database.instance.GetShortCharacterActiveID() < characters.Length - 1)
            {
                characters[Database.instance.GetShortCharacterActiveID()].character.SetActive(false);
                Database.instance.SetShortCharacterActiveID(side);
                characters[Database.instance.GetShortCharacterActiveID()].character.SetActive(true);
                Debug.Log("Персонаж: " + Database.instance.GetShortCharacterActiveID());
                // Проверка на купленность
                if (characters[Database.instance.GetShortCharacterActiveID()].buyed)
                {
                    Database.instance.SetCharacterActiveID(Database.instance.GetShortCharacterActiveID());
                    Database.instance.SaveGameData();
                    Debug.Log("Выбран персонаж: " + Database.instance.GetCharacterActiveID());
                    ControlUIBuyInfo(false);
                }
                else
                {
                    ControlUIBuyInfo(true);
                }
            }
        }

        if (side == -1)
        {
            if (Database.instance.GetShortCharacterActiveID() > 0)
            {
                characters[Database.instance.GetShortCharacterActiveID()].character.SetActive(false);
                Database.instance.SetShortCharacterActiveID(side);
                characters[Database.instance.GetShortCharacterActiveID()].character.SetActive(true);
                Debug.Log("Персонаж: " + Database.instance.GetShortCharacterActiveID());
                // Проверка на купленность
                if (characters[Database.instance.GetShortCharacterActiveID()].buyed)
                {
                    Database.instance.SetCharacterActiveID(Database.instance.GetShortCharacterActiveID());
                    Database.instance.SaveGameData();
                    Debug.Log("Выбран персонаж: " + Database.instance.GetCharacterActiveID());
                    ControlUIBuyInfo(false);
                }
                else
                {
                    ControlUIBuyInfo(true);
                }
            }
        }


        Debug.Log("Персонаж сменился");
    }
}
