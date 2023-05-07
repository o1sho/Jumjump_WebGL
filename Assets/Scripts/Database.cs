using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public int coins;
    public int maxScore;
    public int characterActiveID;
    public int shortCharacterActiveID;
    public List<int> characterBuyedID = new List<int>();
}

public class Database : MonoBehaviour
{
    public PlayerInfo playerInfo;

    public static Database Instance;

    public int coins;
    public int maxScore;
    public int characterActiveID;
    public int shortCharacterActiveID;
    public List<int> characterBuyedID = new List<int>();

    /*
    //Yandex Server Save
    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();
    */

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            Load();
            //LoadExtern(); // Yandex
        }
    }

    public void Save()
    {
        /*
        string jsonString = JsonUtility.ToJson(playerInfo);
        SaveExtern(jsonString);
        */

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        PlayerInfo data = new PlayerInfo();
        data.coins = coins;
        data.maxScore = maxScore;
        data.characterActiveID = characterActiveID;
        data.shortCharacterActiveID = shortCharacterActiveID;
        data.characterBuyedID = characterBuyedID;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            PlayerInfo data = (PlayerInfo)bf.Deserialize(file);
            file.Close();
            coins = data.coins;
            maxScore = data.maxScore;
            characterActiveID = data.characterActiveID;
            shortCharacterActiveID = data.shortCharacterActiveID;
            characterBuyedID = data.characterBuyedID;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    
    /*
    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        playerData.text = playerInfo.coins + " Coins\n" + playerInfo.maxScore + " MaxScore\n" + playerInfo.characterBuyedID + " BuyedCharacter\n";
    }
    */
}
