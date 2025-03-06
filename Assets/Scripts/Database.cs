using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.Jobs;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int coins;
    public int maxScore;
    public int characterActiveID;
    public int shortCharacterActiveID;
    public List<int> characterBuyedID = new List<int>();
}

public class Database : MonoBehaviour
{
    public Data data;
    private string saveKey;

    public static Database instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadGameData();

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData()
    {
        string jsonData = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();

    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            string jsonData = PlayerPrefs.GetString(saveKey);
            data = JsonUtility.FromJson<Data>(jsonData); // Используем Unity JSON десериализатор
            Debug.Log("Data found, stored values loaded!");
        }
        else
        {
            // Если файл не существует, создать новый объект GameData или задать значения по умолчанию.
            data = new Data();
            Debug.Log("No data found, standard values loaded!");
        }
    }

    public void LoadGameDataYandex(string value)
    {
        data = JsonUtility.FromJson<Data>(value);
    }


    //coins
    public void SetCoins(int coins)
    {
        data.coins += coins;
    }

    public int GetCoins()
    {
        return data.coins;
    }
    //

    //highScore
    public void SetMaxScore(int score)
    {
        data.maxScore = score;
    }

    public int GetMaxScore()
    {
        return data.maxScore;
    }
    //

    //characterActiveID
    public void SetCharacterActiveID(int idCharacter)
    {
        data.characterActiveID = idCharacter;
    }

    public int GetCharacterActiveID()
    {
        return data.characterActiveID;
    }
    //

    //shortCharacterActiveID
    public void ChangeShortCharacterActiveID(int side)
    {
        data.shortCharacterActiveID += side;
    }

    public void SetShortCharacterActiveID(int idCharacter)
    {
        data.shortCharacterActiveID = idCharacter;
    }

    public int GetShortCharacterActiveID()
    {
        return data.shortCharacterActiveID;
    }
    //

    //characterBuyedID
    public void SetCharacterBuyedID(int idCharacter)
    {
        data.characterBuyedID.Add(idCharacter);
    }

    public bool CheckCharacterBuyedID(int idCharacter)
    {
        return data.characterBuyedID.Contains(idCharacter);
    }
    //


}
