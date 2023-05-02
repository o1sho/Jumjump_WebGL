using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewPlayerController : MonoBehaviour
{
    [SerializeField] int _pricePlayer;
    [SerializeField] Button _selectButton;
    [SerializeField] Button _buyButton;
    [SerializeField] GameObject _selectInfoText;
    [SerializeField] GameObject _textPrice;

    [SerializeField] SelectCharacterController _selectCharacterController;

    public static Action saveEarnedCoins;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("idActiveCharacter") == _selectCharacterController.idActiveCharacter) _selectButton.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("idActiveCharacter") != _selectCharacterController.idActiveCharacter && PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _selectButton.interactable = false;
        else _selectButton.gameObject.SetActive(true);
        

        // Покупка. Проверка на наличие денег и Проверка на уже купленность
        if (PlayerPrefs.GetInt("Coins") < _pricePlayer || PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) == "Buyed") _buyButton.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("Coins") >= _pricePlayer && PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _buyButton.gameObject.SetActive(true);

        //if (_selectCharacterController.idActiveCharacter == 0 || PlayerPrefs.GetInt("idActiveCharacter") == 0) _buyButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("idActiveCharacter") == _selectCharacterController.idActiveCharacter) _selectButton.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("idActiveCharacter") != _selectCharacterController.idActiveCharacter && PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _selectButton.interactable = false;
        else _selectButton.gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("Coins") < _pricePlayer || PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) == "Buyed") _buyButton.gameObject.SetActive(false);
        else if (PlayerPrefs.GetInt("Coins") >= _pricePlayer && PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _buyButton.gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("Coins") < _pricePlayer) _selectInfoText.SetActive(false);
        if (PlayerPrefs.GetInt("idActiveCharacter") != _selectCharacterController.idActiveCharacter && PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _selectInfoText.SetActive(false);

        if (_selectCharacterController.idActiveCharacter == 0)
        {
            _buyButton.gameObject.SetActive(false);
            PlayerPrefs.SetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter, "Buyed");
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) != "Buyed") _selectButton.interactable = false;
        else if (PlayerPrefs.GetString("PlayerBuyed" + _selectCharacterController.idActiveCharacter) == "Buyed")
        {
            _selectButton.interactable = true;
            _textPrice.SetActive(false);
        }
    }

    public void BuyNewPlayer()
    {
        for (int i = 0; i <= _selectCharacterController.idActiveCharacter; i++)
        {
            if (i == _selectCharacterController.idActiveCharacter)
            {
                CoinsController.coins -= _pricePlayer;
                saveEarnedCoins?.Invoke();
                PlayerPrefs.SetString("PlayerBuyed" + i, "Buyed");
                Debug.Log("Персонаж " + i + " " + PlayerPrefs.GetString("PlayerBuyed" + i));
            }
        }
    }
}
